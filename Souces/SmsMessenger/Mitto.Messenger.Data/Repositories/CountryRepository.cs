using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Data.Repositories.Base;
using System.Data;

namespace Mitto.Messenger.Data.Repositories
{
  public class CountryRepository : BaseRepository<Country>
  {
    public CountryRepository(IDbConnection db): base(db)
    {
    }
  }
}
