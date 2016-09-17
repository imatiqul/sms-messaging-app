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

    public void Dispose()
    {
      repository = null;
    }
  }
}
