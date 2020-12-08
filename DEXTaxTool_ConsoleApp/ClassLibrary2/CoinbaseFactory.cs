using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;

namespace Parser
{
    public class CoinbaseFactory : IPriceRequesterFactory
    {
        Dictionary<string, string> priceFeedUrl;
        public CoinbaseFactory(Dictionary<string,string> priceFeedUrl)
        {
            this.priceFeedUrl = priceFeedUrl;
        }
        public IPriceRequester GetPriceRequester()
        {
            return new CoinbaseRequester(priceFeedUrl);
        }
    }
}
