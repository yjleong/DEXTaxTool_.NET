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
    /// Parser object that gets all required transactions from block explorer with HTTP GET and parses them into ITxn objects 
    /// </summary>
    public class TxnParser
    {
        private ITxnRequester txnRequester;
        private ITxnMapper txnMapper;
        public TxnParser(ITxnRequester txnRequester, ITxnMapper txnMapper)
        {
            this.txnRequester = txnRequester;
            this.txnMapper = txnMapper;
        }

        public Dictionary<TxnTypeEnum, List<ITxn>> deserializeJSON()
        {
            try
            {
                var txnDict = new Dictionary<TxnTypeEnum, List<ITxnMapper>>();
                var taskList = new List<Task<string>>();
                foreach (TxnTypeEnum txnType in Enum.GetValues(typeof(TxnTypeEnum)))
                {
                    taskList.Add(txnRequester.GetTxnsAsync(txnType));
                }
                var result = Task.WhenAll(taskList).Result;
                foreach(var res in result)
                {

                }
                //then use mapper to get ITxn[] back

                //need to be able to handle situations where there's bad connection/can't get any txn from block explorer
                throw new NotImplementedException();
            }
            catch (ArgumentException e) when (e.ParamName != "HttpRequestException")
            {
                //handle exception better
                Console.WriteLine("\nException Caught!");
                Console.WriteLine($"Message :{e.Message} ");
                throw e;
            }
        }

        public Task deserializeJSON_testing ()
        {
            try
            {
                var txnDict = new Dictionary<TxnTypeEnum, List<ITxnMapper>>();
                var taskList = new List<Task<string>>();
                foreach (TxnTypeEnum txnType in Enum.GetValues(typeof(TxnTypeEnum)))
                {
                    taskList.Add(txnRequester.GetTxnsAsync(txnType));
                }

                //then use mapper to get ITxn[] back

                //need to be able to handle situations where there's bad connection/can't get any txn from block explorer
                throw new NotImplementedException();
            }
            catch (ArgumentException e) when (e.ParamName != "HttpRequestException")
            {
                //handle exception better
                Console.WriteLine("\nException Caught!");
                Console.WriteLine($"Message :{e.Message} ");
                throw e;
            }
        }



    }
}
