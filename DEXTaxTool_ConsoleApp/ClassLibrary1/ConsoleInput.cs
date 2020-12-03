using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Input
{
    public class ConsoleInput : IUserInput
    {
        private string apiKey;
        private string ethAddress;
        public string ApiKey
        {
            get
            {
                return apiKey;
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
            Console.WriteLine("Input valid API Etherscan API key");
            apiKey = Console.ReadLine();
        }
    }
}
