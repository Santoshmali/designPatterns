using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.Clear();

            // Establish an event handler to process key press events.
            Console.Write("Press 'X' to quit.");
            while (true)
            {
                Console.WriteLine("Choose your cloud provider you want to execute \r\n 1. Azure \r\n 2. Aws");

                Cloud cloud;
                if (Cloud.TryParse(Console.ReadLine(), out cloud))
                {
                    Console.WriteLine("Choose which pattern you want to execute \r\n 1. Factory \r\n 2. Abstract Factory");

                    //var key = Console.ReadKey();
                    //int num = Convert.ToInt32(Console.ReadLine());
                    Pattern pattern;
                    Enum.TryParse(Console.ReadLine(), out pattern);
                    var factoryMethod = new FactoryMethod();
                    factoryMethod.GetPattern(pattern).Execute(cloud);
                }

                // Start a console read operation. Do not display the input.
                cki = Console.ReadKey(true);
                
                // Exit if the user pressed the 'X' key.
                if (cki.Key == ConsoleKey.X) break;
            }
        }
    }
}
