using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;
using UserInput;

namespace Parser
{
    /// <summary>
    /// Abstract factory provider for specific block explorers
    /// </summary>
    public class TxnParserDepsFactoryProvider
    {
        public static ITxnParserDepsFactory GetFactory(IUserInput userInput, Dictionary<BlockExplorerEnum, Dictionary<TxnTypeEnum, string>> blkExplURLDict)
        {
            switch (userInput.BlkExpl)
            {
                case BlockExplorerEnum.EtherScan:
                    Dictionary<TxnTypeEnum, string> blkExplURL;
                    if (blkExplURLDict.TryGetValue(BlockExplorerEnum.EtherScan, out blkExplURL))
                    {
                        return new EtherScanDepsFactory(userInput, blkExplURL);
                    }
                    //TODO:
                    //Catch cases where cant get URLs and no enums. 
                    else throw new Exception();
                default:
                    throw new Exception();
            }
        }
    }
}
