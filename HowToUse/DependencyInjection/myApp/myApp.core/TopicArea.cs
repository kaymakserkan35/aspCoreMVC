using System;
using System.Collections.Generic;

namespace myApp.core
{
    public class TopicArea : ITopicAreaService
    {
        public string Name { get; set; }

        public IEnumerable<TopicArea> GetAllTopicAreas()
        {
            return new List<TopicArea>
            {
             new TopicArea {Name =".NET Core" },
             new TopicArea {Name ="Docker" },
             new TopicArea { Name ="C#" }
            };
        }
    }
}
