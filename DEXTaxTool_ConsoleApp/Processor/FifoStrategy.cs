using BlockExplorerInfo;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public class FifoStrategy : ITaxStrategy
    {
        public void ProcessTxns(Dictionary<TxnTypeEnum, ITxn[]> txns)
        {
            throw new NotImplementedException();
        }
    }
}
