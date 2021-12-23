using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public enum Pattern
    {
        Factory = 1,
        AbstractFactory = 2
    }

    public class FactoryMethod
    {
        public IPattern GetPattern(Pattern pattern)
        {
            IPattern result;
            switch(pattern)
            {
                case Pattern.Factory:
                    result = new FactoryPattern();
                    break;
                case Pattern.AbstractFactory:
                    result = new AbstractFactoryPattern();
                    break;
                default:
                    result = new DefaultPattern();
                    break;
            }

            return result;
        }
    }
}
