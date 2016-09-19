using Mitto.Messenger.Core.Enums;
using ServiceStack.DataAnnotations;
using System;

namespace Mitto.Messenger.Core.Entities
{
  public class Message
  {
    [AutoIncrement, PrimaryKey]
    public int Id { get; set; }

    [ForeignKey(typeof(Subscriber))]
    public int SenderId { get; set; }

    [ForeignKey(typeof(Subscriber))]
    public int ReceiverId { get; set; }

    public string Text { get; set; }

    [Default((int)MessageType.Sms)]
    public MessageType Type { get; set; }

    [Default((int)MessageState.Success)]
    public MessageState State { get; set; }

    public DateTime Date { get; set; }
  }
}
