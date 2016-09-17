using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Data.Repositories.Base;
using System.Data;

namespace Mitto.Messenger.Data.Repositories
{
  public class SubscriberRepository : BaseRepository<Subscriber>
  {
    public SubscriberRepository(IDbConnection db) : base(db)
    {
    }
  }
}
