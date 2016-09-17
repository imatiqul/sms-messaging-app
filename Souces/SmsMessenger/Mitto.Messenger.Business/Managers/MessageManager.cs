using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.Core.Interfaces;
using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Data.Repositories;
using System.Collections.Generic;
using System.Data;
using ServiceStack;
using System;

namespace Mitto.Messenger.Business.Managers
{
  public class MessageManager : IBaseManager<Message>
  {
    private MessageRepository repository;
    private SubscriberRepository subscriberRepository;
    private CountryManager countryManager;
    
    public MessageManager(IDbConnection db)
    {
      repository = new MessageRepository(db);
      subscriberRepository = new SubscriberRepository(db);
      countryManager = new CountryManager(db);
    }

    public void SaveMessage(MessageDto message)
    {

    }

    public void Dispose()
    {
      repository = null;
      subscriberRepository = null;
      countryManager = null;
    }
  }
}
