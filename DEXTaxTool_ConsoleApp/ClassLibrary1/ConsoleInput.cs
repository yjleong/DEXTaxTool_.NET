using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;


namespace User_Input
{
    public class ConsoleInput : IUserInput
    {
        private string apiKey;
        private string ethAddress;
        private BlockExplorerEnum blkExpl;
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

        public void SetUserInput()
        {
            Console.WriteLine("Input valid Ethereum address:");
            ethAddress = Console.ReadLine();
            Console.WriteLine("EtherScan is only block explorer supported");
            blkExpl = BlockExplorerEnum.EtherScan;
            Console.WriteLine("Input valid API EtherScan API key");
            apiKey = Console.ReadLine();
        }
    }
}
