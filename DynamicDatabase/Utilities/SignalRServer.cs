using Microsoft.AspNetCore.SignalR;

namespace DynamicDatabase.Utilities
{
    public class SignalRServer : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}