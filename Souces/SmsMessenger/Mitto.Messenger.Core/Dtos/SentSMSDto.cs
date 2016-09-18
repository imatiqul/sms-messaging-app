using Mitto.Messenger.Core.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mitto.Messenger.Core.Dtos
{
  [DataContract(Name = "getSentSMSResponse")]
  public class SentSMSDto
  {
    [DataMember(Name = "totalCount")]
    public int TotalSMS { get; set; }

    [DataMember(Name = "items")]
    public List<SMSDto> SMSList { get; set; }
  }

  [DataContract(Name = "sms")]
  public class SMSDto
  {
    [DataMember(Name = "dateTime")]
    public DateTime DateTime { get; set; }

    [DataMember(Name = "mcc")]
    public string MobileCountryCode { get; set; }

    [DataMember(Name = "from")]
    public string Sender { get; set; }

    [DataMember(Name = "to")]
    public string Receiver { get; set; }

    [DataMember(Name = "price")]
    public decimal Price { get; set; }

    [DataMember(Name = "state")]
    public MessageState State { get; set; }
  }
}
