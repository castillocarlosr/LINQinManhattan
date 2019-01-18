using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08LINQinManhattan.Classes
{
    public class RootObject
    {
        public string Type { get; set; }

        public List<Feature> Features { get; set; }
    }
}
