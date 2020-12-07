using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EtherScanJSONDataObjs
{
    public class NormalTxnResponse : BaseTxnResponse
    {
        public NormalTxn[] result;
    }
}
