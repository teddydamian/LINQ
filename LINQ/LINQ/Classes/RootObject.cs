using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LINQ.Classes
{
    public class RootObject
    {
        public string type { get; set; }
        public List<Features> features { get; set; }
    }
}