using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Classes
{
    public class Features
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
}

