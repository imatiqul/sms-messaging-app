using System.Runtime.Serialization;

namespace Mitto.Messenger.Core.Dtos
{
  [DataContract(Name = "country")]
  public class CountryDto
  {
    [IgnoreDataMember]
    public int Id { get; set; }

    [DataMember(Name = "mcc")]
    public string MobileCountryCode { get; set; }

    [DataMember(Name = "cc")]
    public string CountryCode { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "pricePerSMS")]
    public decimal PricePerSms { get; set; }
  }
}
