using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticHttpClient;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;

namespace Parser
{
    public class CoinbaseRequester : IPriceRequester
    {
        private Dictionary<string, string> symbolUrl;
        private HttpClient client;
        private string dateFormat;
        public CoinbaseRequester (Dictionary<string,string> symbolUrl)
        {
            client = HTTPClientProvider.httpClient;
            this.symbolUrl = symbolUrl;
            dateFormat = "yyyy-MM-dd'T'HH:mm'Z'"; //from Coinbase API documentation
        }
        public string GetPrice(ITxn txn)
        {
            //TODO: Make async 
            string uri = symbolUrl[txn.GetToken()];
            uri = uri.Replace("<start_Iso8601>", txn.GetDateIso8601(dateFormat));
            uri = uri.Replace("<end_Iso8601>", txn.GetDateIso8601(dateFormat, 60)); //add 60 seconds to ensure getting prices within minute
            //TODO: Replace with better form of wait when async implemented
            //Wait 500ms because API rate limitation 3 request/sec
            Thread.Sleep(5000);
            Console.WriteLine($"GET request: {uri}");
            var JsonStr = getRequest(uri);
            return extractPrice(JsonStr);
        }

        private string getRequest(string uri)
        {
            try
            {
                //Example URI: https://api.pro.coinbase.com/products/ETH-USD/candles?start=2020-03-29T01:07Z&end=2020-03-29T01:08Z&granularity=60
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
        private string extractPrice(string JsonStr)
        {
            try
            {
                double[][] priceArr = JsonConvert.DeserializeObject<double[][]>(JsonStr);
                return ((priceArr[0][1] + priceArr[0][2] + priceArr[0][3] + priceArr[0][4]) / 4).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while trying to get/extract price from Coinbase");
                throw e;
            }
        }
    }
}
