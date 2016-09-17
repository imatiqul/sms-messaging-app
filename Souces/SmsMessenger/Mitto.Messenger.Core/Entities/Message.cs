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

    [Default(1)]
    public MessageType Type { get; set; }

    [Default(1)]
    public MessageState State { get; set; }

    public DateTime Date { get; set; }
  }
}
