using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                "我",
                "Mike",
                "Jackson",
                "你",
                "测定",
            };
            List<string> ages = new List<string>()
            {
                "11",
                "5",
                "44",
                "6",
                "1589"
            };

            List<string> namesF = names.Select(x => string.Format("{0,-10}", x)).ToList();
            List<string> agesF = ages.Select(x => string.Format("{0,-10}", x)).ToList();

            //string s = string.Format("{0,-10}", "Hello");
            //string t = string.Format("{0,-10}", "K");
            Console.OutputEncoding= Encoding.UTF8;
            Console.WriteLine(string.Join(",",namesF));
            Console.WriteLine(string.Join(",",agesF));
            Console.ReadKey();
        }
    }
}
