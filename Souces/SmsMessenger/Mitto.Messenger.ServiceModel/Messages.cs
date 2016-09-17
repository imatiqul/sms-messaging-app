using Mitto.Messenger.Core.Dtos;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitto.Messenger.ServiceModel
{
  [Route("/countries", "GET")]
  public class GetCountries : IReturn<List<CountryDto>>
  {
  }

  [Route("/sms/send", "GET")]
  public class SendSMS : IReturn<MessageResponseDto>
  {
    public string From { get; set; }
    public string To { get; set; }
    public string Text { get; set; }
  }
  
  [Route("/sms/sent", "GET")]
  public class GetSentSMS : IReturn<List<SentSMSResponseDto>>
  {
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
  }
  
  [Route("/statistics", "GET")]
  public class GetStatistics : IReturn<List<StatisticsResponseDto>>
  {
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public List<string> MobileCountryCodeList { get; set; }
  }
}
