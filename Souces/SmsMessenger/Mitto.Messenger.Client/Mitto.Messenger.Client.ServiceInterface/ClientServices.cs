using Mitto.Messenger.Client.ServiceModel;
using Mitto.Messenger.Core.Dtos;
using ServiceStack;
using ServiceStack.Configuration;
using System.Collections.Generic;

namespace Mitto.Messenger.Client.ServiceInterface
{
  public class ClientServices : Service
  {
    public object Any(GetCountries request)
    {
      var appSettings = new AppSettings();
      JsonServiceClient client = new JsonServiceClient("http://{0}".Fmt(appSettings.Get("MessageServiceAPIUrl")));
      return client.Get<List<CountryDto>>("/countries");
    }
  }
}
