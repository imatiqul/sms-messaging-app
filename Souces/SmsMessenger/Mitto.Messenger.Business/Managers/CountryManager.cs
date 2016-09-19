using Mitto.Messenger.Core.Dtos;
using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Core.Interfaces;
using Mitto.Messenger.Data.Repositories;
using ServiceStack;
using System.Collections.Generic;
using System.Data;

namespace Mitto.Messenger.Business.Managers
{
  public class CountryManager : IBaseManager<Country>
  {
    private CountryRepository repository;

    public CountryManager(IDbConnection db)
    {
      repository = new CountryRepository(db);
    }

    public List<CountryDto> GetCountries()
    {
      return repository.GetAll().ConvertAll(x => x.ConvertTo<CountryDto>());
    }

    public CountryDto GetByCountryAndMobileCountryCode(string cc, string mcc)
    {
      var countryList = repository.Get(x => x.CountryCode == cc && x.MobileCountryCode == mcc);
      if (countryList != null && countryList.Count > 0)
        return countryList[0].ConvertTo<CountryDto>();
      return null;
    }

    public void Dispose()
    {
      repository = null;
    }
  }
}
