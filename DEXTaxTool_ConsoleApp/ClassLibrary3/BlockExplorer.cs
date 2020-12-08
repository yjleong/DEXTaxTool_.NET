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
    }
}
