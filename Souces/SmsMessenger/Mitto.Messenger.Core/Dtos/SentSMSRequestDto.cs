using System;

namespace Mitto.Messenger.Core.Dtos
{
  public class SentSMSRequestDto
  {
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
  }
}
