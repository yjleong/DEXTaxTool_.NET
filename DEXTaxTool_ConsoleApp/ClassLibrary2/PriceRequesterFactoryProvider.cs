using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;
using PriceFeedInfo;

namespace Parser
{
    public class PriceRequesterFactoryProvider
    {
        public static IPriceRequesterFactory GetFactory(IUserInput userInput, PriceFeed priceFeed)
        {
            PriceFeedEnum priceFeedEnum = priceFeed.GetPriceFeedEnum(userInput.PriceFeed);
            var priceFeedUrlDict = priceFeed.GetPriceFeedUrlDict();
            switch (priceFeedEnum)
            {
                case PriceFeedEnum.Coinbase:
                    Dictionary<string, string> priceFeedUrl = priceFeed.GetPriceFeedUrl(priceFeedEnum);
                    return new CoinbaseFactory(priceFeedUrl);
            }
            //TODO:
            //Catch cases where cant get URLs and no enums. Handle exceptions better in general 
            throw new Exception($"Exception: Can't get API end points for {priceFeedEnum}");
        }
    }
}
