using Mitto.Messenger.Core.Enums;
using System.Runtime.Serialization;

namespace Mitto.Messenger.Core.Dtos
{
  [DataContract(Name = "sendSMSResponse")]
  public class SMSResultDto
  {
    [DataMember(Name = "state")]
    public MessageState State { get; set; }
  }
}
