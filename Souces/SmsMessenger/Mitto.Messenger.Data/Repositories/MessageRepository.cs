using Mitto.Messenger.Core.Entities;
using Mitto.Messenger.Data.Repositories.Base;
using System.Data;

namespace Mitto.Messenger.Data.Repositories
{
  public class MessageRepository : BaseRepository<Message>
  {
    public MessageRepository(IDbConnection db) : base(db)
    {
    }
  }
}
