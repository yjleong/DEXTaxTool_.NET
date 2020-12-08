using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockExplorerInfo
{
    //Wrapper class should replace in future 
    public class BlockExplorer
    {
        private BlockExplorerURL blkExplrUrl;
        private BlockExplorerEnumDict blkExplEnumDict;
        public BlockExplorer()
        {
            blkExplrUrl = new BlockExplorerURL();
            blkExplEnumDict = new BlockExplorerEnumDict();
        }

        public BlockExplorerEnum GetBlockExplorerEnum (string str)
        {
            return blkExplEnumDict.EnumDict[str];
        }

        public Dictionary<string,BlockExplorerEnum> GetEnumDict()
        {
            return blkExplEnumDict.EnumDict;
        }

        public Dictionary<BlockExplorerEnum, Dictionary<TxnTypeEnum, string>> GetBlockExplorereUrlDict()
        {
            return blkExplrUrl.BlockExplorerURLDict;
        }
        public Dictionary<TxnTypeEnum, string> GetBlockExplorerURL(BlockExplorerEnum blkExplEnum)
        {
            return blkExplrUrl.BlockExplorerURLDict[blkExplEnum];
        }
    }
}
