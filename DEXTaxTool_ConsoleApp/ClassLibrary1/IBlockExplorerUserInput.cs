using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;

namespace UserInput
{
    public interface IBlockExplorerUserInput
    {
        string EthAddress { get; }
        string ApiKey { get;}
        string BlkExpl { get; }
        void SetUserInput();
    }
}
