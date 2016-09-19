using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitto.Messenger.Core.Helpers
{
  public abstract class StringHelper
  {
    public static string SubString(string baseString, int startIndex, int length)
    {
      return baseString.Substring(startIndex, length);
    }
  }
}
