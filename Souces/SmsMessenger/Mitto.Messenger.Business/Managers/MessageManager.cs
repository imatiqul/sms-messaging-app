using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Core.Enums;
using Mitto.Messenger.Core.Interfaces;
using Mitto.Messenger.Data.Repositories;
using System.Collections.Generic;
using System.Data;

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

    public MessageState SaveMessage(MessageDto message)
    {
      var state = MessageState.SUCCESS;

      return state;
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
      subscriberRepository = null;
      countryManager = null;
    }
  }
}
