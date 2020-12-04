using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;
using BlockExplorerInfo;
using Parser;

namespace DEXTaxTool_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //require some input to enable End to End run with default values? 
            var blkExplURL = new BlockExplorerURL();
            IUserInput userInput = new ConsoleInput();
            userInput.SetUserInput();
            ITxnParserDepsFactory txnParserDepsFactory = TxnParserDepsFactoryProvider.GetFactory(userInput);
            var txnParser = new TxnParser(txnParserDepsFactory.GetTxnRequester(), txnParserDepsFactory.GetTxnMapper());
            //based on user input of what block explorer, need to use abstract factory pattern to provide appropriate requester and mapper 

        }
    }
}
