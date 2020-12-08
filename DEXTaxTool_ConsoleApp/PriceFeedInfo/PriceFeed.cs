using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceFeedInfo
{
    public class PriceFeed
    {
        private PriceFeedEnumDict priceFeedEnumDict;
        private PriceFeedURL priceFeedUrl;
        public PriceFeed()
        {
            priceFeedEnumDict = new PriceFeedEnumDict();
            priceFeedUrl = new PriceFeedURL();
        }

        public PriceFeedEnum GetPriceFeedEnum (string str)
        {
            return priceFeedEnumDict.EnumDict[str];
        }
        public Dictionary<string, PriceFeedEnum> GetEnumDict()
        {
            return priceFeedEnumDict.EnumDict;
        }

        public Dictionary<PriceFeedEnum, Dictionary<string,string>> GetPriceFeedUrlDict()
        {
            return priceFeedUrl.PriceFeedURLDict;
        }

        public Dictionary <string,string> GetPriceFeedUrl(PriceFeedEnum priceFeedEnum)
        {
            return priceFeedUrl.PriceFeedURLDict[priceFeedEnum];
        }


    }
}
