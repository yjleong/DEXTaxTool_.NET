using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;


namespace UserInput
{
    public class ConsoleInput : IUserInput
    {
        private string apiKey;
        private string ethAddress;
        private BlockExplorerEnum blkExpl;
        private Dictionary<string, BlockExplorerEnum> enumDict;
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
        }

        public BlockExplorerEnum BlkExpl
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
        public ConsoleInput(Dictionary<string, BlockExplorerEnum> blkExplDict)
        {
            this.enumDict = blkExplDict;
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
            BlockExplorerEnum tmpEnum;
            if (enumDict.TryGetValue(tmpStr, out tmpEnum))
            {
                blkExpl = tmpEnum;
            }
            else
            {
                Console.WriteLine("Input not recognized. Defaulting to EtherScan");
                blkExpl = BlockExplorerEnum.EtherScan;
            }
            Console.WriteLine("Input valid API key");
            apiKey = Console.ReadLine();
        }
    }
}
