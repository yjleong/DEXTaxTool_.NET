using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;

namespace TxnParser
{
    public interface ITxnRequester
    {
        string GetTxns(TxnTypeEnum txnTypeEnum);
    }
}
