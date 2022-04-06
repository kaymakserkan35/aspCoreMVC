using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.core
{
    public class MyFirstHostedService : IHostedService
    {
        protected async override Task
         ExecuteAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
