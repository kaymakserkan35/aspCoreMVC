using System;
using System.Threading;
using System.Threading.Tasks;

namespace myApp.core
{
    public interface IHostedService
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
