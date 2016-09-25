using System;
using System.Collections.Generic;

namespace Mitto.Messenger.Core.Interfaces
{
  public interface IBaseManager<T> : IDisposable where T : class
  {
  }
}
