using Mitto.Messenger.Core.Enums;
using System;

namespace Mitto.Messenger.Core.Dtos
{
  public class SentSMSResponseDto
  {
    public DateTime DateTime { get; set; }
    public string MobileCountryCode { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public decimal Price { get; set; }
    public MessageState State { get; set; }
  }
}
