using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserInput;
using BlockExplorerInfo;
using StaticHttpClient;

namespace Parser
{
    public class EtherScanTxnRequester : ITxnRequester
    {
        private HttpClient httpClient;
        private IUserInput userInput; 
        private Dictionary<TxnTypeEnum, string> urlDict;
        public EtherScanTxnRequester(IUserInput userInput, Dictionary<TxnTypeEnum, string> urlDict)
        {
            this.httpClient = HTTPClientProvider.httpClient;
            this.userInput = userInput;
            this.urlDict = urlDict;
        }

        public string GetTxns(TxnTypeEnum txnTypeEnum)
        {
            string uri ="";
            switch(txnTypeEnum)
            {
                case TxnTypeEnum.Normal:
                    uri = urlDict[TxnTypeEnum.Normal];
                    break;
                case TxnTypeEnum.Internal:
                    uri = urlDict[TxnTypeEnum.Internal];
                    break;
                case TxnTypeEnum.ERC20:
                    uri = urlDict[TxnTypeEnum.ERC20];
                    break;
            }
            uri = uri.Replace("<ETHAddressHere>", userInput.EthAddress);
            uri = uri.Replace("<APIKeyHere>", userInput.ApiKey);


            throw new NotImplementedException();
        }
    }
}
