using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageWatermark.Services
{
    public class DataCreatedEvent
    {
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
