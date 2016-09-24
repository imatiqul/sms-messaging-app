using Mitto.Messenger.Client.ServiceModel;
using Mitto.Messenger.Core.Dtos;
using ServiceStack;
using ServiceStack.Configuration;
using System;
using System.Collections.Generic;

namespace Mitto.Messenger.Client.ServiceInterface
{
  public class ClientServices : Service
  {
    public string ServiceUrl
    {
      get
      {
        var appSettings = new AppSettings();
        return "http://{0}".Fmt(appSettings.Get("MessageServiceAPIUrl"));
      }
    }

    public string Extension
    {
      get
      {
        var appSettings = new AppSettings();
        return appSettings.Get("MessageServiceAPIExtension");
      }
    }

    public object Any(GetCountries request)
    {
      var apiUrl = "/countries";

      return "{0}{1}.{2}".Fmt(ServiceUrl, apiUrl, Extension)
        .GetJsonFromUrl()
        .FromJson<List<CountryDto>>();
    }

    public object Any(SendSMS request)
    {
      var apiUrl = "/sms/send";

      var url = "{0}{1}.{2}".Fmt(ServiceUrl, apiUrl, Extension);
      url = url.AddQueryParam("from", request.From);
      url = url.AddQueryParam("to", request.To);
      url = url.AddQueryParam("text", request.Text);

      return url.GetJsonFromUrl()
       .FromJson<SMSResultDto>();
    }

    public object Any(GetSentSMS request)
    {
      var apiUrl = "/sms/sent";

      var url = "{0}{1}.{2}".Fmt(ServiceUrl, apiUrl, Extension);
      url = url.AddQueryParam("from", request.From);
      url = url.AddQueryParam("to", request.To);
      url = url.AddQueryParam("skip", request.Skip);
      url = url.AddQueryParam("take", request.Take);

      return url.GetJsonFromUrl()
       .FromJson<SentSMSDto>();
    }

    public object Any(GetStatistics request)
    {
      var apiUrl = "/statistics";

      var url = "{0}{1}.{2}".Fmt(ServiceUrl, apiUrl, Extension);
      url = url.AddQueryParam("from", request.From);
      url = url.AddQueryParam("to", request.To);
      url = url.AddQueryParam("mccList", request.MobileCountryCodeList);

      return url.GetJsonFromUrl()
       .FromJson<List<StatisticsDto>>();
    }
  }
}
