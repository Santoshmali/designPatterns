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

            Console.WriteLine("Choose which pattern you want to execute \r\n 1. Factory \r\n 2. Abstract Factory");

            //var key = Console.ReadKey();
            //int num = Convert.ToInt32(Console.ReadLine());
            Pattern pattern;
            Pattern.TryParse(Console.ReadLine(), out pattern);
            var factoryMethod = new FactoryMethod();
            factoryMethod.GetPattern(pattern).Execute();

            Console.ReadKey();
        }
    }
}
