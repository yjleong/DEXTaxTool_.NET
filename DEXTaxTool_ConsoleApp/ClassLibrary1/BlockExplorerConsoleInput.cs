using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;


namespace UserInput
{
    public class BlockExplorerConsoleInput : IBlockExplorerUserInput
    {
        private string apiKey;
        private string ethAddress;
        private string blkExpl;
        private Dictionary<string, BlockExplorerEnum> enumDict;
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
        public BlockExplorerConsoleInput(Dictionary<string, BlockExplorerEnum> blkExplDict)
        {
            enumDict = blkExplDict;
        }

        public void SetUserInput()
        {
            //TODO:
            //add checks for valid address and api key
            Console.WriteLine("Input valid Ethereum address:");
            ethAddress = Console.ReadLine();
            Console.WriteLine("Input block explorer to use. Available block explorers are:");
            foreach(var kvp in enumDict)
            {
                Console.WriteLine(kvp.Key);
            }
            var tmpStr = Console.ReadLine();
            if (enumDict.ContainsKey(tmpStr))
            {
                blkExpl = tmpStr;
            }
            else
            {
                Console.WriteLine("Input not recognized. Defaulting to EtherScan");
                blkExpl = "EtherScan";
            }
            Console.WriteLine("Input valid API key");
            apiKey = Console.ReadLine();
        }
    }
}
