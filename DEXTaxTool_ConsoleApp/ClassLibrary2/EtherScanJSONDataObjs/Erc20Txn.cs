using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EtherScanJSONDataObjs
{
    public class Erc20Txn:BaseTxn, ITxn
    {
        public string nonce;
        public string blockHash;
        public string tokenName;
        public string tokenSymbol;
        public string tokenDecimal;
        public string transactionIndex;
        public string gasPrice;
        public string cumulativeGasUsed;
        public string confirmations;

        public override string GetToken()
        {
            return tokenSymbol;
        }
    }
}
