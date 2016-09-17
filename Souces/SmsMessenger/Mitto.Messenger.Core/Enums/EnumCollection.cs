using ServiceStack.DataAnnotations;

namespace Mitto.Messenger.Core.Enums
{
  [EnumAsInt]
  public enum MessageType
  {
    SMS = 1
  }

  [EnumAsInt]
  public enum MessageState
  {
    SUCCESS = 1,
    FAILED
  }
}
