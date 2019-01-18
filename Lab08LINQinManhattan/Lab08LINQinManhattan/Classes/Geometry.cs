using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08LINQinManhattan.Classes
{
    public class Geometry
    {
        public string Type { get; set; }

        public List<double> Coordinates { get; set; }
    }
}
