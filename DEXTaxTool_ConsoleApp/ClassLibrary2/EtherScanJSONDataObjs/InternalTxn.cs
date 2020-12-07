using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EtherScanJSONDataObjs
{
    public class InternalTxn : BaseTxn, ITxn
    {
        public string type;
        public string traceId;
        public string isError;
        public string errCode;

        public override string GetToken()
        {
            return "ETH";
        }
    }
}
