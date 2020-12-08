using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticHttpClient;
using System.Net.Http;

namespace Processor
{
    public class CoinbaseRequester : IPriceRequester
    {
        private Dictionary<string, string> symbolUrl;
        private HttpClient client;
        public CoinbaseRequester (Dictionary<string,string> symbolUrl)
        {
            client = HTTPClientProvider.httpClient;
            this.symbolUrl = symbolUrl;
        }
        public string GetPrice(string tokenSymbol, string start_Iso8601, string end_Iso8601, string granularity = "60")
        {
            string uri = symbolUrl[tokenSymbol];
            uri = uri.Replace("<start_Iso8601>", start_Iso8601);
            uri = uri.Replace("<end_Iso8601>", end_Iso8601);
            uri = uri.Replace("<granularity>", granularity);
            return getRequest(uri);
        }

        private string getRequest(string uri)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(uri).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
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
