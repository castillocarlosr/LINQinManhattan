using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08LINQinManhattan.Classes
{
    public class Feature
    {
        public string Type { get; set; }

        public Properties Properties { get; set; }
        
        public Geometry Geometry { get; set; }
    }
}
