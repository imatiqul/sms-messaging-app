namespace Mitto.Messenger.Core.Dtos
{
  public class CountryDto
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string CountryCode { get; set; }

    public string MobileCountryCode { get; set; }

    public decimal PricePerSms { get; set; }
  }
}
