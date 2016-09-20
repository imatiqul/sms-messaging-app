using Mitto.Messenger.Core.Dtos;
using ServiceStack;
using System.Collections.Generic;


namespace Mitto.Messenger.Client.ServiceModel
{
  [Route("/countries", "GET")]
  public class GetCountries : IReturn<List<CountryDto>>
  {
  }

}
