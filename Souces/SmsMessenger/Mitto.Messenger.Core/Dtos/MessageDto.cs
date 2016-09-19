using Mitto.Messenger.Core.Helpers;
using System;

namespace Mitto.Messenger.Core.Dtos
{
  public class MessageDto
  {
    public string From { get; set; }
    public string To { get; set; }
    public string Text { get; set; }

    public MobileIndentiferDto Sender
    {
      get
      {
        MobileIndentiferDto dto = Activator.CreateInstance<MobileIndentiferDto>();

        string countryCode = string.Empty;
        int startIndex = 0;
        if (From.StartsWith("+"))
        {
          startIndex = 1;
        }
        countryCode = StringHelper.SubString(From, startIndex, 2);
        string mobileCountryCode = StringHelper.SubString(From, startIndex + 2, 3);
        string mobileNumber = StringHelper.SubString(From, startIndex + 5, From.Length - (startIndex + 5));

        dto.CountryCode = countryCode;
        dto.MobileCountryCode = mobileCountryCode;
        dto.MobileNumber = mobileNumber;

        return dto;
      }

    }
    public MobileIndentiferDto Receiver
    {
      get
      {
        MobileIndentiferDto dto = Activator.CreateInstance<MobileIndentiferDto>();

        string countryCode = string.Empty;
        int startIndex = 0;
        if (To.StartsWith("+"))
        {
          startIndex = 1;
        }
        countryCode = StringHelper.SubString(To, startIndex, 2);
        string mobileCountryCode = StringHelper.SubString(To, startIndex + 2, 3);
        string mobileNumber = StringHelper.SubString(To, startIndex + 5, To.Length - (startIndex + 5));

        dto.CountryCode = countryCode;
        dto.MobileCountryCode = mobileCountryCode;
        dto.MobileNumber = mobileNumber;

        return dto;
      }
    }
  }
}
