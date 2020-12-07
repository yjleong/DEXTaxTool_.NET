using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EtherScanJSONDataObjs
{
    public class Erc20TxnResponse : BaseTxnResponse
    {
        public Erc20Txn[] result;
    }
}
