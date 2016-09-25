using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Core.Enums;
using Mitto.Messenger.Core.Interfaces;
using Mitto.Messenger.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mitto.Messenger.Business.Managers
{
  public class MessageManager : IBaseManager<Message>
  {
    private MessageRepository repository;
    private SubscriberManager subscriberManager;
    private CountryManager countryManager;

    public MessageManager(IDbConnection db)
    {
      repository = new MessageRepository(db);
      subscriberManager = new SubscriberManager(db);
      countryManager = new CountryManager(db);
    }

    private SubscriberDto GetSubscriberDto(MessageDto message, bool isReceiver = false)
    {
      string countryCode = string.Empty;
      string mobileCountryCode = string.Empty;
      string mobileNumber = string.Empty;

      if (isReceiver)
      {
        countryCode = message.Receiver.CountryCode;
        mobileCountryCode = message.Receiver.MobileCountryCode;
        mobileNumber = message.Receiver.MobileNumber;
      }
      else
      {
        countryCode = message.Sender.CountryCode;
        mobileCountryCode = message.Sender.MobileCountryCode;
        mobileNumber = message.Sender.MobileNumber;
      }

      var countryDto = countryManager.GetByCountryAndMobileCountryCode(countryCode, mobileCountryCode);

      SubscriberDto subscriberDto = subscriberManager.GetByCountryAndMobileNumber(countryDto.Id, mobileNumber);
      if (subscriberDto == null)
      {
        subscriberDto = Activator.CreateInstance<SubscriberDto>();
        subscriberDto.CountryId = countryDto.Id;
        subscriberDto.MobileNumber = mobileNumber;
        subscriberDto = subscriberManager.SaveSubscriber(subscriberDto);
      }
      return subscriberDto;
    }

    public MessageState SaveMessage(MessageDto message)
    {
      SubscriberDto senderSubscriberDto = GetSubscriberDto(message);
      SubscriberDto receiverSubscriberDto = GetSubscriberDto(message, true);

      var sentDateTime = DateTime.UtcNow;
      var messageObj = new Message
      {
        SenderId = senderSubscriberDto.Id,
        ReceiverId = receiverSubscriberDto.Id,
        Text = message.Text,
        Date = DateTime.UtcNow,
        State = MessageState.Success,
        Type = MessageType.Sms
      };

      repository.Save(messageObj);

      if (messageObj.Id > 0)
        return messageObj.State;

      return MessageState.Failed;
    }

    public List<SMSDto> GetSentSMS(SMSFilterDto filter)
    {
      var smsList = new List<SMSDto>();

      var messageList = repository.Get(x => (x.Date >= filter.From && x.Date <= filter.To), filter.Skip, filter.Take);
      var subscriberList = subscriberManager.GetAll();
      var countryList = countryManager.GetCountries();

      messageList.ForEach(message =>
          {
            var sender = subscriberList.Find(x => x.Id == message.SenderId);
            var receiver = subscriberList.Find(x => x.Id == message.ReceiverId);
            var country = countryList.Find(x => x.Id == sender.CountryId);
            var smsCount = Math.Ceiling(((decimal)message.Text.Length / 160));

            var sms = new SMSDto
            {
              DateTime = message.Date,
              Receiver = sender.MobileNumber,
              Sender = receiver.MobileNumber,
              MobileCountryCode = country.MobileCountryCode,
              Price = smsCount * country.PricePerSms,
              State = message.State
            };

            smsList.Add(sms);
          });

      return smsList;
    }

    public List<StatisticsDto> GetStatisticsReport(StatisticsFilterDto filter)
    {
      var reports = new List<StatisticsDto>();
      var countries = new List<CountryDto>();

      if (filter.MobileCountryCodeList !=null && filter.MobileCountryCodeList.Count > 0)
        countries = countryManager.GetAllByMobileCountryCodes(filter.MobileCountryCodeList);
      else
        countries = countryManager.GetCountries();

      var subscribers = subscriberManager.GetAllByCountryIds(countries.Select(x => x.Id).ToList());
      var subscriberIds = subscribers.Select(x => x.Id).ToList();
      var messageList = repository.Get(x => (x.Date >= filter.From && x.Date <= filter.To && subscriberIds.Contains(x.SenderId))).OrderBy(x => x.Date.ToString("yyyy-MM-dd"));

      var query = (from message in messageList
                   join subscriber in subscribers on message.SenderId equals subscriber.Id
                   join country in countries on subscriber.CountryId equals country.Id
                   select new
                   {
                     Date = message.Date.ToString("yyyy-MM-dd"),
                     MCC = country.MobileCountryCode,
                     PricePerSMS = country.PricePerSms,
                     Price = Math.Ceiling(((decimal)message.Text.Length / 160)) * country.PricePerSms
                   });

      reports = (from res in query
                 let countryKey = new { mcc = res.MCC, price = res.PricePerSMS }
                 orderby res.Date
                 group res by new { res.MCC, res.Date } into grp
                 select new StatisticsDto
                 {
                   Day = DateTime.Parse(grp.Key.Date),
                   MobileCountryCode = grp.Key.MCC,
                   Count = grp.Count(),
                   PricePerSms = countries.Single(x => x.MobileCountryCode == grp.Key.MCC).PricePerSms,
                   TotalPrice = grp.Sum(x => x.Price)
                 }
                ).ToList();

      return reports;
    }

    public void Dispose()
    {
      repository = null;
      subscriberManager = null;
      countryManager = null;
    }
  }
}
