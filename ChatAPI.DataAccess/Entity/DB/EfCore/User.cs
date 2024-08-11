using System;
using System.Collections.Generic;

namespace ChatAPI.DataAccess.Entity.DB.EfCore;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();
}
