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
        public static ITxnParserDepsFactory GetFactory(IBlockExplorerUserInput userInput, Dictionary<BlockExplorerEnum, Dictionary<TxnTypeEnum, string>> blkExplURLDict, Dictionary<string, BlockExplorerEnum> enumDict)
        {
            BlockExplorerEnum blkExplEnum;
            //check if user selected Block explorer is a valid block explorer that is supported
            if (enumDict.TryGetValue(userInput.BlkExpl, out blkExplEnum))
            {
                switch (blkExplEnum)
                {
                    case BlockExplorerEnum.EtherScan:
                        Dictionary<TxnTypeEnum, string> blkExplURL;
                        //for supported block explorer, check if exists known API endpoints
                        if (blkExplURLDict.TryGetValue(blkExplEnum, out blkExplURL))
                        {
                            return new EtherScanDepsFactory(userInput, blkExplURL);
                        }
                        //TODO:
                        //Catch cases where cant get URLs and no enums. Handle exceptions better in general 
                        else throw new Exception($"Exception: Can't get {blkExplEnum.ToString()} API endpoints");
                    default:
                        throw new Exception($"Exception: Unknown/unsupported block explorer");
                }
            }
            else
            {
                throw new Exception("Exception: Block Explorer not supported.");
            }
        }
    }
}
