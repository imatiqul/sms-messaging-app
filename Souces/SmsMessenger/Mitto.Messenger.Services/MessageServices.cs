using Mitto.Messenger.Business.Managers;
using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.ServiceModel;
using ServiceStack;
using ServiceStack.FluentValidation;
using System.Collections.Generic;

namespace Mitto.Messenger.Services
{
  public class SendSMSValidator : AbstractValidator<SendSMS>
  {
    public SendSMSValidator()
    {
      RuleFor(x => x.From).NotEmpty().WithMessage("Sender cannot be empty.");
      RuleFor(x => x.To).NotEmpty().WithMessage("Receiver cannot be empty.");
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
    public object Any(GetCountries request)
    {
      using (CountryManager manager = new CountryManager(Db))
      {
        return manager.GetCountries();
      }
    }
  }
}
