using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Core.Interfaces;
using Mitto.Messenger.Data.Repositories;
using System;
using ServiceStack;
using System.Data;
using System.Collections.Generic;

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

    public SubscriberDto GetByCountryAndMobileNumber(int countryId, string mobileNumber)
    {
      var senderSubscriberList = subscriberRepository.Get(x => x.CountryId == countryId && x.MobileNumber == mobileNumber);
      if (senderSubscriberList != null && senderSubscriberList.Count > 0)
      {
        return senderSubscriberList[0].ConvertTo<SubscriberDto>();
      }
      return null;
    }

    public List<SubscriberDto> GetAll()
    {
      return subscriberRepository.GetAll().ConvertAll(x => x.ConvertTo<SubscriberDto>());
    }

    public List<SubscriberDto> GetAllByCountryIds(List<int> countries)
    {
      return subscriberRepository.Get(x=> countries.Contains(x.CountryId)).ConvertAll(x => x.ConvertTo<SubscriberDto>());
    }

    public void Dispose()
    {
      subscriberRepository = null;
    }

  }
}
