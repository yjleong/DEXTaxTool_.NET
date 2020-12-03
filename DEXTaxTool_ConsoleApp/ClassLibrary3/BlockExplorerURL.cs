using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockExplorerInfo
{
    public static class BlockExplorerURL
    {
        public static Dictionary<BlockExplorerEnum, string> BlockExplorerURLDict;

        // TODO:
        // Get URL's from DB in future 
        static BlockExplorerURL()
        {
            BlockExplorerURLDict.Add(BlockExplorerEnum.EtherScan, "http://api.etherscan.io/api?module=account&action=");
        }
    }
}
