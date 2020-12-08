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
        private HttpClient client;
        private IUserInput userInput; 
        private Dictionary<TxnTypeEnum, string> urlDict;
        public EtherScanTxnRequester(IUserInput userInput, Dictionary<TxnTypeEnum, string> urlDict)
        {
            client = HTTPClientProvider.httpClient;
            this.userInput = userInput;
            this.urlDict = urlDict;
        }


        public async Task<string> GetTxnsAsync(TxnTypeEnum txnTypeEnum)
        {
            string uri = urlDict[txnTypeEnum];
            uri = uri.Replace("<ETHAddressHere>", userInput.EthAddress);
            uri = uri.Replace("<APIKeyHere>", userInput.ApiKey);
            return await getRequest(uri);
        }

        private async Task<string> getRequest(string uri)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                //handle exception better 
                Console.WriteLine("\nException Caught!");
                Console.WriteLine($"Message :{e.Message} ");
                throw e;
            }
        }
    }
}
