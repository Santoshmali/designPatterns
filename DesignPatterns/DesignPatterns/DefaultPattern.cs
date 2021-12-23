using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class DefaultPattern : IPattern
    {
        public void Execute(Cloud cloud)
        {
            Console.WriteLine("No Implementation...");
        }
    }
}
