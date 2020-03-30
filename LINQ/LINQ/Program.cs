using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using LINQ.Classes;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/Users/teddydamian/Desktop/codefellow/code401ASP.NET/LINQ/LINQ/LINQ/assets/data.JSON";

            JObject jObject = CreateJObject(path);

            RootObject rootObject = new RootObject();

            rootObject = jObject.ToObject<RootObject>();

            Query(rootObject);
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

        static void Query(RootObject rootObject)
        {
            
            var queryOneList = rootObject.features.Select(x => x.properties.Neighborhood);           
            Console.WriteLine("Show all Neighborhoods: ");

            int count = 0;
            
                foreach (string neighborhood in queryOneList)
                {

                if (neighborhood.Equals(""))
                    {
                    count++;
                        Console.WriteLine($"{ count}. No hood");
                    }
                    else
                    {
                        count++;
                        Console.Write($"{count}. {neighborhood} \n");
                    }
                }
            
            Console.WriteLine();
            Console.Write("Press Enter to see 2");
            Console.ReadLine();

            var noDuplicates = queryOneList.Where(x => x != "");
            var queryTwoList = noDuplicates.Distinct();
            count = 0;
            foreach (string hood in queryTwoList)
            {
                    count++;
                    Console.WriteLine($"{count}. {hood} ");
            }
        }
    }
}

