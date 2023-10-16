using Microsoft.AspNetCore.SignalR;

namespace SignalrReact
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
    public class ChatMessage
    {
        public string User { get; set; }

        public string Message { get; set; }
    }
}
