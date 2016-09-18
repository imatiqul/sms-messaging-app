using Mitto.Messenger.Business.Managers;
using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.ServiceModel;
using ServiceStack;
using ServiceStack.FluentValidation;

namespace Mitto.Messenger.Services
{
  public class SendSMSValidator : AbstractValidator<SendSMS>
  {
    public SendSMSValidator()
    {
      RuleFor(x => x.Sender).NotEmpty().WithMessage("Sender cannot be empty.");
      RuleFor(x => x.Receiver).NotEmpty().WithMessage("Receiver cannot be empty.");
      RuleFor(x => x.Text).NotEmpty().WithMessage("Message cannot be empty.");
    }
  }

  public class GetSentSMSValidator : AbstractValidator<GetSentSMS>
  {
    public GetSentSMSValidator()
    {
      RuleFor(x => x.From).NotEmpty().WithMessage("From Datetime cannot be empty.");
      RuleFor(x => x.To).NotEmpty().WithMessage("To Datetime cannot be empty.");
    }
  }

  public class GetStatisticsValidator : AbstractValidator<GetStatistics>
  {
    public GetStatisticsValidator()
    {
      RuleFor(x => x.From).NotEmpty().WithMessage("From Datetime cannot be empty.");
      RuleFor(x => x.To).NotEmpty().WithMessage("To Datetime cannot be empty.");
    }
  }

  public class MessageServices : Service
  {
    public object Get(GetCountries request)
    {
      using (var manager = new CountryManager(Db))
      {
        return manager.GetCountries();
      }
    }

    public object Get(SendSMS request)
    {
      using (var manager = new MessageManager(Db))
      {
        var messageDto = request.ConvertTo<MessageDto>();
        var state = manager.SaveMessage(messageDto);
        return new SMSResultDto { State = state };
      }
    }
    
    public object Get(GetSentSMS request)
    {
      using (var manager = new MessageManager(Db))
      {
        var filter = request.ConvertTo<SMSFilterDto>();
        var smsList = manager.GetSentSMS(filter);
        return new SentSMSDto { SMSList = smsList, TotalSMS = smsList.Count };
      }
    }

    public object Get(GetStatistics request)
    {
      using (var manager = new MessageManager(Db))
      {
        var filter = request.ConvertTo<StatisticsFilterDto>();
        var reports = manager.GetStatisticsReport(filter);
        return reports;
      }
    }
  }
}
