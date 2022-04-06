using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class MessageHub : Hub
{
    public Task JoinGroup(string groupName)
    {
        return  Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendMessage(string sender, string message)
    {
        await Clients.All.SendAsync("SendMessage", sender, message);
    }

    public async Task SendMessageToGroup(string groupname, string sender, string message)
    {
       // await Clients.All.SendAsync("SendMessage", sender, message);
         await Clients.Group(groupname).SendAsync("SendMessage", sender, message);
    }
}