﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceFeedInfo
{
    public class PriceFeedURL
    {
        public Dictionary<PriceFeedEnum, Dictionary<string, string>> PriceFeedURLDict;

        // TODO:
        // Get URL's from DB in future and have it be connected to BlockExploereEnumDict or load up some form of JSON
        public PriceFeedURL()
        {
            var coinbaseUrl = new Dictionary<string, string>();
            var priceFeedURLDict = new Dictionary<PriceFeedEnum, Dictionary<string, string>>();
            //Known Tickers with USD/USDC pairing on CBPro
            //TODO: Simplify and generalize because URL are the same except for USD/USDC
            coinbaseUrl.Add("ETH", "https://api.pro.coinbase.com/products/ETH-USD/candles?start=<start_Iso8601>&end=<end_Iso8601>&granularity=<granularity>");
            coinbaseUrl.Add("DAI", "https://api.pro.coinbase.com/products/DAI-USDC/candles?start=<start_Iso8601>&end=<end_Iso8601>&granularity=<granularity>");
            coinbaseUrl.Add("MKR", "https://api.pro.coinbase.com/products/MKR-USD/candles?start=<start_Iso8601>&end=<end_Iso8601>&granularity=<granularity>");
            priceFeedURLDict.Add(PriceFeedEnum.Coinbase, coinbaseUrl);
        }
    }
}
