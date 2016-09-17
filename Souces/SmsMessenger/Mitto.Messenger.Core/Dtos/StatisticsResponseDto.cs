using System;

namespace Mitto.Messenger.Core.Dtos
{
  public class StatisticsResponseDto
  {
    public DateTime Day { get; set; }
    public string MobileCountryCode { get; set; }
    public decimal PricePerSms { get; set; }
    public int Count { get; set; }
    public decimal TotalPrice { get; set; }
  }
}
