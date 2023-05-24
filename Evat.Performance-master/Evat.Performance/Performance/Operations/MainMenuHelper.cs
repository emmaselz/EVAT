using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evat.Performance.Performance.Operations
{
    internal static class MainMenuHelper
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("==== EVAT PERFOMANCE SOFTWARE ====");
            Console.WriteLine("==================================");
            Console.WriteLine("");
            Console.WriteLine("1.VIEW PERFORMANCE INFOMATION:");
            Console.WriteLine("     1A.ALGORITHM VERSION [1.0]\n     1B.ALGORITHM VERSION [2.0]\n     1C.PERSOL VERSION [1.0]");
            Console.WriteLine("");
            Console.WriteLine("2.ENVIROMENT:");
            Console.WriteLine("     2A.ALGORITHM VERSION [1.0]\n     2B.ALGORITHM VERSION [2.0]\n     2C.PERSOL VERSION [1.0]");
            Console.WriteLine("");
            Console.WriteLine("3.ENDPOINT DEFAILTS:\n     3A.ALGORITHM VERSION [1.0]\n     3B.ALGORITHM VERSION [2.0]\n     3C.PERSOL VERSION [1.0]");
            Console.WriteLine("");
            Console.WriteLine("4.Exit");

            Console.Write("Please choose from the options below: ");
        }
    }
}
