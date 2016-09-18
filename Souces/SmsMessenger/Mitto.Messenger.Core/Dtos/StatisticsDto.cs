using System;
using System.Runtime.Serialization;

namespace Mitto.Messenger.Core.Dtos
{
  [DataContract(Name = "statisticRecord")]
  public class StatisticsDto
  {
    [DataMember(Name = "day")]
    public DateTime Day { get; set; }

    [DataMember(Name = "mcc")]
    public string MobileCountryCode { get; set; }

    [DataMember(Name = "pricePerSMS")]
    public decimal PricePerSms { get; set; }

    [DataMember(Name = "count")]
    public int Count { get; set; }

    [DataMember(Name = "totalPrice")]
    public decimal TotalPrice { get; set; }
  }
}
