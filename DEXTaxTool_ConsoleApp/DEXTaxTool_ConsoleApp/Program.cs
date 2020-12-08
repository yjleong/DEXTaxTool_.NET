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
                //TODO: Include some JSON deserializer that can read the values and load it into ConsoleInput
                var blkExpl = new BlockExplorer();
                var priceFeed = new PriceFeed();
                //Get user input on what block explorer and price feed to use
                IUserInput userInput = new ConsoleInput(blkExpl.GetEnumDict(),priceFeed.GetEnumDict());
                userInput.SetUserInput();
                //based on user input of what block explorer, use abstract factory to provide appropriate requester and mapper 
                IMapper_RequesterFactory mapper_RequesterFactory = Mapper_RequesterFactoryProvider.GetFactory(userInput, blkExpl);
                //get price requester based on user input
                IPriceRequesterFactory priceRequesterFactory = PriceRequesterFactoryProvider.GetFactory(userInput, priceFeed);
                //var txnParser = new TxnParser(mapper_RequesterFactory.GetTxnRequester(), mapper_RequesterFactory.GetTxnMapper(), priceRequesterFactory.GetPriceRequester());
                var txnParser = new TxnParser(mapper_RequesterFactory.GetTxnRequester(), mapper_RequesterFactory.GetTxnMapper());
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
