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
    /// Abstract factory for EtherScan.
    /// Provides EtherScan specific TxnMapper and TxnRequester objects for the Parser object to use
    /// </summary>
    class EtherScanFactory : IMapper_RequesterFactory
    {
        private IUserInput userInput;
        Dictionary<TxnTypeEnum, string> blkExplURL;
        public EtherScanFactory(IUserInput userInput,  Dictionary<TxnTypeEnum, string> blkExplURL)
        {
            this.userInput = userInput;
            this.blkExplURL = blkExplURL;
        }
        public ITxnMapper GetTxnMapper()
        {
            return new EtherScanTxnMapper();
        }

        public ITxnRequester GetTxnRequester()
        {
            return new EtherScanTxnRequester(userInput, blkExplURL);
        }
    }
}
