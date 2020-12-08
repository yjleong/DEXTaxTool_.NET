using BlockExplorerInfo;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public class LifoStrategy : ITaxStrategy
    {
        private IPriceRequester priceRequester;
        public LifoStrategy(IPriceRequester priceRequester)
        {
            this.priceRequester = priceRequester;
        }

        public void ProcessTxns(Dictionary<TxnTypeEnum, ITxn[]> txns)
        {
            throw new NotImplementedException();
        }
    }
}
