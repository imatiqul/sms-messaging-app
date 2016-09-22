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
        return appSettings.Get("MessageServiceAPIUrl");
      }
    }

    public object Any(GetCountries request)
    {
      return "http://{0}/countries.json".Fmt(ServiceUrl)
        .GetJsonFromUrl()
        .FromJson<List<CountryDto>>();
    }

    public object Any(SendSMS request)
    {
      var client = new JsonServiceClient("http://{0}".Fmt(ServiceUrl));
      return client.Get<SMSResultDto>("/sms/send.json?from={0}&to={1}&text={2}".Fmt(Uri.EscapeDataString(request.From), Uri.EscapeDataString(request.To), Uri.EscapeDataString(request.Text)));
    }

    public object Any(GetSentSMS request)
    {
      var client = new JsonServiceClient("http://{0}{1}".Fmt(ServiceUrl, "/sms/sent.json"));
      return client.Get<SentSMSDto>(request);
    }

    public object Any(GetStatistics request)
    {
      var client = new JsonServiceClient("http://{0}{1}".Fmt(ServiceUrl, "/sms/statistics.json"));
      return client.Get<List<StatisticsDto>>(request);
    }
  }
}
