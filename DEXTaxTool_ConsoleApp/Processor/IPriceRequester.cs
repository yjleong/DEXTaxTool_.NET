using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public interface IPriceRequester
    {
        double GetPrice(string tokenSymbol);
    }
}
