using System;
using System.Collections.Generic;

namespace ChatAPI.DataAccess.Entity.DB.EfCore;

public partial class Message
{
    public int MessageId { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual User? Receiver { get; set; }

    public virtual User? Sender { get; set; }
}
