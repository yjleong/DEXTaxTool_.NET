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
            //Checks and gets block exploprer user specified
            BlockExplorerEnum blkExplEnum = blkExpl.GetBlockExplorerEnum(userInput.BlkExpl);
            switch (blkExplEnum)
            {
                case BlockExplorerEnum.EtherScan:
                    //Get associated block explorerer API endpoint URLs
                    var blkExplURL = blkExpl.GetBlockExplorerURL(blkExplEnum);
                    return new EtherScanFactory(userInput, blkExplURL);
            }
            //TODO:
            //Catch cases where cant get URLs and no enums. Handle exceptions better in general 
            throw new Exception($"Exception: Can't get API end points for {blkExplEnum}");
        }
    }
}
