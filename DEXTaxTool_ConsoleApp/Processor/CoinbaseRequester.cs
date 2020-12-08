using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticHttpClient;
using System.Net.Http;
using System.Threading;

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
        public double GetPrice(string tokenSymbol, string start_Iso8601, string end_Iso8601, string granularity = "60")
        {
            string uri = symbolUrl[tokenSymbol];
            uri = uri.Replace("<start_Iso8601>", start_Iso8601);
            uri = uri.Replace("<end_Iso8601>", end_Iso8601);
            uri = uri.Replace("<granularity>", granularity);
            return getRequest(uri);
        }

        private double getRequest(string uri)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(uri).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                //Need to wait a little bit because of rate limiting, 3 request/second
                //TODO: find better way to wait.
                Thread.Sleep(400);


                return;
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
