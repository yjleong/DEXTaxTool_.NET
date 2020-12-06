using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;

namespace Parser
{
    /// <summary>
    /// Deserializes EtherScan JSON and outputs Txn objects 
    /// </summary>
    class EtherScanTxnMapper : ITxnMapper
    {

        public ITxn[] MapToTxn(TxnTypeEnum txnTypeEnum, string JSONstr)
        {
            switch (txnTypeEnum)
            {
                case TxnTypeEnum.Normal:
                    break;
                case TxnTypeEnum.ERC20:
                    break;
                case TxnTypeEnum.Internal:
                    break;
            }

            throw new NotImplementedException();
        }

    }
}
