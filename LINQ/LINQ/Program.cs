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

        /// <summary>
        /// Query for all calls
        /// </summary>
        /// <param name="rootObject">List after parse</param>
        static void Query(RootObject rootObject)
        {
            // Query 1 : Lambda for all list including no neighbordhood
            var allList = rootObject.features.Select(x => x.properties.Neighborhood);           
            Console.WriteLine("Press Enter to show all Neighborhoods.");
            Console.ReadLine();

            int count = 0;
            
                foreach (string neighborhood in allList)
                {

                        count++;
                        Console.Write($" {count}. {neighborhood} ;");
                    
                }

            Console.WriteLine();
            // Query 2 : Lambda for alllist without no hood
            Console.WriteLine();
            Console.Write("Press Enter to see to see everything excluding ones with no hoods.");
            Console.ReadLine();

            var listWithoutNoHood = allList.Where(x => x != "");
            count = 0;
            foreach (string neighborhood in listWithoutNoHood)
            {

                if (neighborhood.Equals(""))
                {
                    count++;
                    Console.WriteLine($"{ count}. No hood");
                }
                else
                {
                    count++;
                    Console.Write($" {count}. {neighborhood} ;");
                }
            }
            Console.WriteLine();
            // Query 3 : Distinct(); to show no duplicates
            Console.WriteLine();
            Console.Write("Press Enter to see to see everything without duplicates. \n");
            Console.ReadLine();

            var noDuplicates = listWithoutNoHood.Distinct();
            count = 0;
            foreach (string hood in noDuplicates)
            {
                    count++;
                    Console.WriteLine($" {count}. {hood}");
            }

            // Query 4 : Lambda with 1, 2, 3
            Console.WriteLine();
            Console.Write("Press Enter to see to see everything using single query.");
            Console.ReadLine();
            var allInOne = allList.Where(x => x != "").Distinct();
            count = 0;
            foreach (string hood in allInOne)
            {
                count++;
                Console.WriteLine($" {count}. {hood}");
            }

            // Query 5 : Combining 1, 2, 3
            Console.WriteLine();
            Console.Write("Press Enter to see to see everything using LINQ query.");
            Console.ReadLine();

            var linqQuery = (from item in rootObject.features where item.properties.Neighborhood != "" select item.properties.Neighborhood).Distinct();

            count = 0;
            foreach (string hood in linqQuery)
            {
                count++;
                Console.WriteLine($" {count}. {hood}" +
                    $"");
            }

        }
    }
}

