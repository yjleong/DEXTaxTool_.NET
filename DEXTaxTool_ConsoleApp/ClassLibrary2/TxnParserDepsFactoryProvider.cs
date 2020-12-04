using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;
using UserInput;

namespace Parser
{
    public class TxnParserDepsFactoryProvider
    {
        public static ITxnParserDepsFactory GetFactory(IUserInput userInput)
        {
            switch (userInput.BlkExpl)
            {
                case BlockExplorerEnum.EtherScan:
                    return new EtherScanFactory(userInput);
                default:
                    //TODO:
                    //Catch exceptions where some enum not known
                    throw new Exception();
            }
        }
    }
}
