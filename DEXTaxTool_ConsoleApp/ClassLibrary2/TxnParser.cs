﻿using System;
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

        public Dictionary<TxnTypeEnum, ITxn[]> GetTxnObjs()
        {
            try
            {
                var txnDict = new Dictionary<TxnTypeEnum, ITxn[]>();
                var taskList = new List<Task<string>>();
                foreach (TxnTypeEnum txnType in Enum.GetValues(typeof(TxnTypeEnum)))
                {
                    taskList.Add(txnRequester.GetTxnsAsync(txnType));
                }
                //Double check if this is good practice
                string[] JsonTxnStrings = Task.WhenAll(taskList).Result;
                foreach(TxnTypeEnum txnType in Enum.GetValues(typeof(TxnTypeEnum)))
                {
                    var txns = txnMapper.MapToTxn(txnType, JsonTxnStrings[(int)txnType]);
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
