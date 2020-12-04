using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInput;

namespace Parser
{
    class EtherScanFactory : ITxnParserDepsFactory
    {
        private IUserInput userInput;
        public EtherScanFactory(IUserInput userInput)
        {
            this.userInput = userInput;
        }
        public ITxnMapper GetTxnMapper()
        {
            throw new NotImplementedException();
        }

        public ITxnRequester GetTxnRequester()
        {
            throw new NotImplementedException();
        }
    }
}
