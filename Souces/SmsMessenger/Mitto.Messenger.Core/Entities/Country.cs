using ServiceStack.DataAnnotations;

namespace Mitto.Messenger.Core.Entities
{
  public class Country
  {
    [AutoIncrement, PrimaryKey]
    public int Id { get; set; }

    public string Name { get; set; }

    [StringLength(3)]
    public string CountryCode { get; set; }

    [StringLength(3)]
    public string MobileCountryCode { get; set; }

    [DecimalLength(3)]
    public decimal PricePerSms { get; set; }
  }
}
