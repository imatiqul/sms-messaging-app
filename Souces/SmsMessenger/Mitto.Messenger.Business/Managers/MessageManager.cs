using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Core.Enums;
using Mitto.Messenger.Core.Interfaces;
using Mitto.Messenger.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using ServiceStack;

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
      else {
        countryCode = message.Sender.CountryCode;
        mobileCountryCode = message.Sender.MobileCountryCode;
        mobileNumber = message.Sender.MobileNumber;
      }

      var countryDto = countryManager.GetByCountryAndMobileCountryCode(countryCode, mobileCountryCode);

      SubscriberDto subscriberDto = subscriberManager.GetByCountrAndMobileNumber(countryDto.Id, mobileNumber);
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

      return smsList;
    }

    public List<StatisticsDto> GetStatisticsReport(StatisticsFilterDto filter)
    {
      var reports = new List<StatisticsDto>();

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
