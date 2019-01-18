using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab08LINQinManhattan.Classes;
using Newtonsoft.Json;

namespace Lab08LINQinManhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello New York City!!!!");
            Console.WriteLine("");
            NewYorkJSON();
            //Console.ReadLine();
        }
        
        static void NewYorkJSON()
        {
            string path = "../../../data.json";
            string txt = "";
            
            using (StreamReader newFileCity = File.OpenText(path))
            {
                txt = newFileCity.ReadToEnd();
            }

            RootObject manhattan = JsonConvert.DeserializeObject<RootObject>(txt);

            //can not use string type here.  Needs to be var.  I tried.
            var data = manhattan.Features.Select(x => x).Select(x => x.Properties).Select(x => x.Neighborhood);

            Console.WriteLine("Starting with Lambda expressions");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("*****************  Output of All Neighborhoods  ******************************** ");
            Console.WriteLine("===============================================================================");
            var neighborhoodsAll = data.Select(x => x);
            foreach (var name in neighborhoodsAll)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("*****************  Filtered out No Names       ****************************** ");
            Console.WriteLine("*****************  Neighborhoods WITH names  ******************************** ");
            Console.WriteLine("===============================================================================");
            var neighborhoodsFilter = neighborhoodsAll.Where(x => x != "");
            foreach (var name in neighborhoodsFilter)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("*****************  REMOVED the DUPLICATE Neighborhoods ****************************** ");
            Console.WriteLine("===============================================================================");
            var neighborhoodsRemoveDuplicate = neighborhoodsFilter.Distinct();
            foreach (var name in neighborhoodsRemoveDuplicate)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("*****************  Consolidate into Single Query ****************************** ");
            Console.WriteLine("===============================================================================");
            var consolidateSingeQuery = data.Where(x => x != "").Distinct();
            foreach (var name in consolidateSingeQuery)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("*****************  ReWrite in opposing Methods ****************************** ");
            Console.WriteLine("*****************  LINQ into Single Query       ****************************** ");
            Console.WriteLine("===============================================================================");
            var linq = (from x in data
                        where x != ""
                        select x).Distinct();

            foreach (var name in linq)
            {
                Console.WriteLine(name);
            }           

            Console.ReadLine();
        }
    }
}
