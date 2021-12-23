using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public enum Cloud
    {
        Azure = 1,
        Aws = 2
    }
    public interface IPattern
    {
        void Execute(Cloud cloud);
    }
}
