using Mitto.Messenger.Core.Dtos;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mitto.Messenger.Client.ServiceModel
{
  [Route("/countries", "GET")]
  public class GetCountries : IReturn<List<CountryDto>>
  {
  }

  [DataContract]
  [Route("/sms/send", "GET")]
  public class SendSMS : IReturn<SMSResultDto>
  {
    [DataMember(Name = "from")]
    public string From { get; set; }

    [DataMember(Name = "to")]
    public string To { get; set; }

    [DataMember(Name = "text")]
    public string Text { get; set; }
  }

  [DataContract]
  [Route("/sms/sent", "GET")]
  public class GetSentSMS : IReturn<SentSMSDto>
  {
    [DataMember(Name = "from")]
    public DateTime From { get; set; }

    [DataMember(Name = "to")]
    public DateTime To { get; set; }

    [DataMember(Name = "skip")]
    public int Skip { get; set; }

    [DataMember(Name = "take")]
    public int Take { get; set; }
  }

  [DataContract]
  [Route("/statistics", "GET")]
  public class GetStatistics : IReturn<List<StatisticsDto>>
  {
    [DataMember(Name = "from")]
    public DateTime From { get; set; }

    [DataMember(Name = "to")]
    public DateTime To { get; set; }

    [DataMember(Name = "mccList")]
    public List<string> MobileCountryCodeList { get; set; }
  }
}
