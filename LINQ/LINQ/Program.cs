using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/Users/teddydamian/Desktop/codefellow/code401ASP.NET/LINQ/LINQ/LINQ/assets/data.JSON";
            string st = File.ReadAllText(path);

            JObject jObject = CreateJObject(st);

        }

        /// <summary>
        /// creates a JObject using streamreader
        /// </summary>
        /// <param name="path"></param>
        /// <returns>JObject</returns>
        public static JObject CreateJObject(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                JObject jList = (JObject)JToken.ReadFrom(new JsonTextReader(sr));

                return jList;
            }
        }


    }
}

