using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockExplorerInfo
{
    public class BlockExplorerURL
    {
        public Dictionary<BlockExplorerEnum, Dictionary<TxnTypeEnum, string>> BlockExplorerURLDict;

        // TODO:
        // Get URL's from DB in future 
        public BlockExplorerURL()
        {
            var etherScanURL = new Dictionary<TxnTypeEnum, string>();
            BlockExplorerURLDict = new Dictionary<BlockExplorerEnum, Dictionary<TxnTypeEnum, string>>();
            etherScanURL.Add(TxnTypeEnum.Normal,"http://api.etherscan.io/api?module=account&action=txlist&address=<ETHAddressHere>&startblock=0&endblock=99999999&sort=asc&apikey=<APIKeyHere>");
            etherScanURL.Add(TxnTypeEnum.Erc20, "http://api.etherscan.io/api?module=account&action=tokentx&address=<ETHAddressHere>&startblock=0&endblock=999999999&sort=asc&apikey=<APIKeyHere>");
            etherScanURL.Add(TxnTypeEnum.Internal, "http://api.etherscan.io/api?module=account&action=txlistinternal&address=<ETHAddressHere>&startblock=0&endblock=99999999&sort=asc&apikey=<APIKeyHere>");
            BlockExplorerURLDict.Add(BlockExplorerEnum.EtherScan,etherScanURL);
        }
    }
}
