﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.core
{
    public interface ITopicAreaService
    {
        IEnumerable<TopicArea> GetAllTopicAreas();
    }
}
