using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;
using BlockExplorerInfo;

namespace Parser
{
    public class TxnParser
    {
        private ITxnRequester txnRequester;
        private ITxnMapper txnMapper;
        public TxnParser(ITxnRequester txnRequester, ITxnMapper txnMapper)
        {
            this.txnRequester = txnRequester;
            this.txnMapper = txnMapper;
        }

        public Dictionary<TxnTypeEnum ,List<ITxn>> deserializeJSON()
        {
            var txnDict = new Dictionary<TxnTypeEnum, List<ITxn>>();
            string normalTxnStr = txnRequester.GetTxns(TxnTypeEnum.Normal);
            string erc20TxnStr = txnRequester.GetTxns(TxnTypeEnum.ERC20);
            string internalTxnStr = txnRequester.GetTxns(TxnTypeEnum.Internal);
            //then use mapper to get ITxn[] back
            //need to be able to handle situations where there's bad connection/can't get any txn from block explorer
            throw new NotImplementedException();
        }
            
    }
}
