using ServiceStack.DataAnnotations;

namespace Mitto.Messenger.Core.Entities
{
  public class Subscriber
  {
    [AutoIncrement, PrimaryKey]
    public int Id { get; set; }

    [ForeignKey(typeof(Country))]
    public int CountryId { get; set; }

    [StringLength(10)]
    public string MobileNumber { get; set; }
  }
}
