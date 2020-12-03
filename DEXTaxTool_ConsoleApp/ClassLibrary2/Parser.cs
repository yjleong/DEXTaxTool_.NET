using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Input;

namespace TxnParser
{
    class Parser
    {
        private IUserInput userInput;

        private ITxnRequester txnRequester;
        public Parser(IUserInput userInput, ITxnRequester txnRequester)
        {
            this.userInput = userInput;
            this.txnRequester = txnRequester;
        }

        public ITxn deserializeJSON(string JSON)
        {
            var URI = "";
            var JSONstr = txnRequester.GetTxns(URI);
            throw new NotImplementedException();
        }
            
    }
}
