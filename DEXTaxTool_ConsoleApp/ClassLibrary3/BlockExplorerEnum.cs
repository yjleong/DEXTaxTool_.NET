using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockExplorerInfo
{
    //Supproted block explorers
    // TODO: 
    // Get enums from DB in future
    public enum BlockExplorerEnum
    {
        EtherScan
    }

    //TODO: Find better place for this, its inherently bound to the enum though
    public class BlockExplorerEnumDict
    {
        public Dictionary<string, BlockExplorerEnum> EnumDict;
        public BlockExplorerEnumDict()
        {
            var enumDict = new Dictionary<string, BlockExplorerEnum>();
            foreach (BlockExplorerEnum blkExplEnum in Enum.GetValues(typeof(BlockExplorerEnum)))
            {
                enumDict.Add(blkExplEnum.ToString(), blkExplEnum);
            }
            EnumDict = enumDict;
        }

    }
}
