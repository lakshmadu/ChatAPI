using ChatAPI.DataAccess.Entity.DB.EfCore;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatAPI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatAppDbContext _context;

        public ChatHub(ChatAppDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            // Save the message to the database
            var sender = await _context.Users.FindAsync(senderId);
            var receiver = await _context.Users.FindAsync(receiverId);

            if (sender == null || receiver == null)
                return; // Handle user not found

            var newMessage = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = message,
                Timestamp = DateTime.UtcNow
            };

            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();

            // Send the message to the specific receiver
            await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", sender.Username, message);
        }

        public override Task OnConnectedAsync()
        {
            // Add the connected user to a user-specific group
            var userId = Context.UserIdentifier;
            if (userId != null)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, userId);
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            // Remove the disconnected user from the group
            var userId = Context.UserIdentifier;
            if (userId != null)
            {
                Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
