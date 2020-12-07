using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;

namespace UnitTestProject1
{
    class StubTxnReqester : ITxnRequester
    {
        public Task<string> GetTxnsAsync(TxnTypeEnum txnTypeEnum)
        {
            switch (txnTypeEnum)
            {
                case TxnTypeEnum.Normal:
                    //Return string? or load up some JSON? 
                    break;
                case TxnTypeEnum.Internal:
                    //Return string? or load up some JSON? 
                    break;
                case TxnTypeEnum.Erc20:
                    //Return string? or load up some JSON? 
                    break;
            }

        }
    }
}
