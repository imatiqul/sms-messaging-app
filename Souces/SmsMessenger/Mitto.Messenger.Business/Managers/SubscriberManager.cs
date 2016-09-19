using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Core.Interfaces;
using Mitto.Messenger.Data.Repositories;
using System;
using ServiceStack;
using System.Data;

namespace Mitto.Messenger.Business.Managers
{
  public class SubscriberManager : IBaseManager<Subscriber>
  {
    private SubscriberRepository subscriberRepository;

    public SubscriberManager(IDbConnection db)
    {
      subscriberRepository = new SubscriberRepository(db);
    }
    public SubscriberDto SaveSubscriber(SubscriberDto subscriberDto)
    {
      var subscriber = subscriberDto.ConvertTo<Subscriber>();
      subscriberRepository.Save(subscriber);

      return subscriber.ConvertTo<SubscriberDto>();
    }

    public SubscriberDto GetByCountrAndMobileNumber(int countryId, string mobileNumber)
    {
      var senderSubscriberList = subscriberRepository.Get(x => x.CountryId == countryId && x.MobileNumber == mobileNumber);
      if (senderSubscriberList != null && senderSubscriberList.Count > 0)
      {
        return senderSubscriberList[0].ConvertTo<SubscriberDto>();
      }
      return null;
    }

    public void Dispose()
    {
      subscriberRepository = null;
    }
  }
}
