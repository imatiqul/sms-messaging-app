using ServiceStack.DataAnnotations;

namespace Mitto.Messenger.Core.Enums
{
  [EnumAsInt]
  public enum MessageType
  {
    Sms = 1
  }

  [EnumAsInt]
  public enum MessageState
  {
    Success = 1,
    Failed
  }
}
