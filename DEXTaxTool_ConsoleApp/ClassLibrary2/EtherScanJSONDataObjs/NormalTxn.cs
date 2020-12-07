using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EtherScanJSONDataObjs
{
    public class NormalTxn :BaseTxn, ITxn
    {
        public string nonce;
        public string blockHash;
        public string transactionIndex;
        public string gasPrice;
        public string isError;
        public string txreceipt_status;
        public string cumulativeGasUsed;
        public string confirmations;

        public override string GetToken()
        {
           return "ETH";
        }
    }
}
