using System;
using System.Collections.Generic;

namespace Mitto.Messenger.Core.Dtos
{
  public class StatisticsRequestDto
  {
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public List<string> MobileCountryCodeList { get; set; }
  }
}
