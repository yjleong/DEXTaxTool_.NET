using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;

namespace TxnParser
{
    class Parser
    {
        private ITxnRequester txnRequester;
        public Parser(ITxnRequester txnRequester)
        {
            this.txnRequester = txnRequester;
        }

        public ITxn deserializeJSON()
        {
            var JSONstr = txnRequester.GetTxns();
            throw new NotImplementedException();
        }
            
    }
}
