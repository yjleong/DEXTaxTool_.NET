using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;
using BlockExplorerInfo;
using PriceFeedInfo;
using Parser;

namespace DEXTaxTool_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //require some input to enable End to End run with default values? 
                //Include some JSON deserializer that can read the values and load it into ConsoleInput
                var blkExpl = new BlockExplorer();
                var priceFeed = new PriceFeed();
                IUserInput userInput = new ConsoleInput(blkExpl.GetEnumDict(),priceFeed.GetEnumDict());
                userInput.SetUserInput();
                IMapper_RequesterFactory mapper_RequesterFactory = Mapper_RequesterFactoryProvider.GetFactory(userInput, blkExpl);
                IPriceRequesterFactory priceRequesterFactory = PriceRequesterFactoryProvider.GetFactory(userInput, priceFeed);
                var txnParser = new TxnParser(mapper_RequesterFactory.GetTxnRequester(), mapper_RequesterFactory.GetTxnMapper(), priceRequesterFactory.GetPriceRequester());
                //based on user input of what block explorer, need to use abstract factory pattern to provide appropriate requester and mapper 
                Dictionary<TxnTypeEnum, ITxn[]> txns = txnParser.GetTxnObjs();
            }
            catch (Exception e)
            {
                //Handle exception better 
                Console.WriteLine($"Exiting program Last exception is message :{e.Message} ");
                throw e;
            }
        }
    }
}
