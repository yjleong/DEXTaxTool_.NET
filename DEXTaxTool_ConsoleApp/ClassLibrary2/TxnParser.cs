using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;
using BlockExplorerInfo;

namespace Parser
{
    /// <summary>
    /// Parser object that gets all required transactions from block explorer and price feed, parses them, and outputs ITxn objects 
    /// </summary>
    public class TxnParser
    {
        private ITxnRequester txnRequester;
        private ITxnMapper txnMapper;
        private IPriceRequester priceRequester;
        public TxnParser(ITxnRequester txnRequester, ITxnMapper txnMapper, IPriceRequester priceRequester)
        {
            this.txnRequester = txnRequester;
            this.txnMapper = txnMapper;
            this.priceRequester = priceRequester;
        }
        //Old ctor
        public TxnParser(ITxnRequester txnRequester, ITxnMapper txnMapper)
        {
            this.txnRequester = txnRequester;
            this.txnMapper = txnMapper;
        }

        public Dictionary<TxnTypeEnum, ITxn[]> GetTxnObjs()
        {
            try
            {
                var txnDict = new Dictionary<TxnTypeEnum, ITxn[]>();
                var taskList = new List<Task<string>>();
                Console.WriteLine("Getting transactions from block explorer");
                foreach (TxnTypeEnum txnType in Enum.GetValues(typeof(TxnTypeEnum)))
                {
                    Console.WriteLine($"Getting ${txnType.ToString()}");
                    taskList.Add(txnRequester.GetTxnsAsync(txnType));
                }
                //TODO: Double check if this is good practice
                string[] JsonTxnStrings = Task.WhenAll(taskList).Result;
                foreach(TxnTypeEnum txnType in Enum.GetValues(typeof(TxnTypeEnum)))
                {
                    var txns = txnMapper.MapToTxn(txnType, JsonTxnStrings[(int)txnType]);
                    if (priceRequester != null)
                    {
                        //Check if have price and set price
                        foreach (var txn in txns)
                        {
                            if (string.IsNullOrEmpty(txn.GetPrice()))
                            {
                                //TODO: Figure out how to do async get and set price in txn 
                                Console.WriteLine($"Getting price for {txn.GetToken()} at timestamp {txn.GetTimeStamp()}, hash : {txn.GetHash()}");
                                string price = priceRequester.GetPrice(txn);
                                Console.WriteLine($"Price: {price}");
                                txn.SetPrice(price);
                            }
                        }  
                    }
                    txnDict.Add(txnType, txns);
                }
                return txnDict;
           }
            //need to be able to handle situations where there's bad connection/can't get any txn from block explorer
            catch (Exception e)
            {
                //handle exception better
                Console.WriteLine("\nException Caught!");
                Console.WriteLine($"Message :{e.Message} ");
                throw e;
            }
        }
    }
}
