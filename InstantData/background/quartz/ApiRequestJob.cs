
using background.SignalR;
using Microsoft.AspNetCore.SignalR;
using Quartz;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace background.quartz
{
    public class ApiRequestJob : IJob
    {
        IHubContext<MyHub> hubContext;

        public ApiRequestJob(IHubContext<MyHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await hubContext.Clients.All.SendAsync("GetRequestFromApi_ClientMethod");
        }
    }
}
