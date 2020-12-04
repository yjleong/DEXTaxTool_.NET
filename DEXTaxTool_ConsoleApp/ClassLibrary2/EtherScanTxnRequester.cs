using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserInput;

namespace TxnParser
{
    public class EtherScanTxnRequester : ITxnRequester
    {
        private HttpClient httpClient;
        private IUserInput userInput; 
        public EtherScanTxnRequester(HttpClient httpClient, IUserInput userInput)
        {
            this.httpClient = httpClient;
            this.userInput = userInput;
        }

        public string GetTxns(TxnTypeEnum txnTypeEnum)
        {
            string URI = ""; 
            throw new NotImplementedException();
        }
    }
}
