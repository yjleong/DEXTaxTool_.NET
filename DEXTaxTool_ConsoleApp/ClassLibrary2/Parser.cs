using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;

namespace TxnParser
{
    class Parser
    {
        private ITxnRequester txnRequester;
        private ITxnMapper txnMapper;
        public Parser(ITxnRequester txnRequester, ITxnMapper txnMapper)
        {
            this.txnRequester = txnRequester;
            this.txnMapper = txnMapper;
        }

        public Dictionary<TxnTypeEnum ,List<ITxn>> deserializeJSON()
        {
            var normalTxnStr = txnRequester.GetTxns(TxnTypeEnum.Normal);
            var erc20TxnStr = txnRequester.GetTxns(TxnTypeEnum.ERC20);
            var internalTxnStr = txnRequester.GetTxns(TxnTypeEnum.Internal);
            //then use mapper to get ITxn[] back

            throw new NotImplementedException();
        }
            
    }
}
