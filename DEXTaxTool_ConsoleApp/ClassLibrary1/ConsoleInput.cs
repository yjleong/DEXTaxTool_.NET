using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;
using PriceFeedInfo;


namespace UserInput
{
    public class ConsoleInput : IUserInput
    {
        private string apiKey;
        private string ethAddress;
        private string blkExpl;
        private string priceFeed;
        private Dictionary<string, BlockExplorerEnum> blkExplEnumDict;
        private Dictionary<string, PriceFeedEnum> priceFeedEnumDict;
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
        }

        public string BlkExpl
        {
            get
            {
                return blkExpl;
            }
        }

        public string EthAddress
        {
            get
            {
                return ethAddress; 
            }
        }

        public string PriceFeed
        {
            get
            {
                return priceFeed;
            }
        }

        public ConsoleInput(Dictionary<string, BlockExplorerEnum> blkExplDict, Dictionary<string, PriceFeedEnum> priceFeedDict)
        {
            blkExplEnumDict = blkExplDict;
            priceFeedEnumDict = priceFeedDict;
        }

        public void SetUserInput()
        {
            //TODO:
            //add checks for valid address and api key
            Console.WriteLine("Input valid Ethereum address:");
            ethAddress = Console.ReadLine();
            Console.WriteLine("Input block explorer to use. Available block explorers are:");
            foreach(var kvp in blkExplEnumDict)
            {
                Console.WriteLine(kvp.Key);
            }
            var tmpStr = Console.ReadLine();
            if (blkExplEnumDict.ContainsKey(tmpStr))
            {
                blkExpl = tmpStr;
            }
            else
            {
                Console.WriteLine("Input not recognized. Defaulting to EtherScan");
                blkExpl = "EtherScan";
            }
            Console.WriteLine("Input valid API key for block explorer");
            apiKey = Console.ReadLine();
            Console.WriteLine("Input price feed to use. Available price feed are:");
            foreach (var kvp in priceFeedEnumDict)
            {
                Console.WriteLine(kvp.Key);
            }
            tmpStr = Console.ReadLine();
            if (blkExplEnumDict.ContainsKey(tmpStr))
            {
                blkExpl = tmpStr;
            }
            else
            {
                Console.WriteLine("Input not recognized. Defaulting to Coinbase");
                priceFeed = "Coinbase";
            }
        }
    }
}
