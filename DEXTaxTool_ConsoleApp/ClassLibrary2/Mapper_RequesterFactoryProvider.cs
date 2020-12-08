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
    public class Mapper_RequesterFactoryProvider
    {
        public static IMapper_RequesterFactory GetFactory(IUserInput userInput, BlockExplorer blkExpl)
        {
            BlockExplorerEnum blkExplEnum = blkExpl.GetBlockExplorerEnum(userInput.BlkExpl);
            var blkExplURLDict = blkExpl.GetBlockExplorereUrlDict();
            //check if user selected Block explorer is a valid block explorer that is supported
            switch (blkExplEnum)
            {
                case BlockExplorerEnum.EtherScan:
                    Dictionary<TxnTypeEnum, string> blkExplURL = blkExpl.GetBlockExplorerURL(blkExplEnum);
                    return new EtherScanFactory(userInput, blkExplURL);
            }
            //TODO:
            //Catch cases where cant get URLs and no enums. Handle exceptions better in general 
            throw new Exception($"Exception: Can't get API end points for {blkExplEnum}");
            
        }
    }
}
