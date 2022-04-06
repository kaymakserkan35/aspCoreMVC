using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace background.SignalR
{
    public class MyHub : Hub
    {
        public async Task GetRequestFromApi_ServerMethod()
        {
            await Clients.All.SendAsync("GetRequestFromApi_ClientMethod");
        }
    }
}
