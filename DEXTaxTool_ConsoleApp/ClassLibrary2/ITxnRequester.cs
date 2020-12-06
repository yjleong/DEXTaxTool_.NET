using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;
using BlockExplorerInfo;

namespace Parser
{
    public interface ITxnRequester
    {
        Task<string> GetTxnsAsync(TxnTypeEnum txnTypeEnum);
    }
}
