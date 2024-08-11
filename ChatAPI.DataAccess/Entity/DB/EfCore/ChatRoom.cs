using System;
using System.Collections.Generic;

namespace ChatAPI.DataAccess.Entity.DB.EfCore;

public partial class ChatRoom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
