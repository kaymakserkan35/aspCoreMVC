using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uı.signalr
{
    public class myhub : Hub
    {
        public async Task servermethod()
        {
            await Clients.All.SendAsync("clientmethod");
        }
    }
}
