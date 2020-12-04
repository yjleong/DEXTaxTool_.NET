using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;

namespace Parser
{
    public interface ITxnMapper
    {
        ITxnMapper[] MapToTxn(TxnTypeEnum txnTypeEnum, string JSONstr);
    }
}
