using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;

namespace UserInput
{
    public interface IUserInput
    {
        string EthAddress { get; }
        string ApiKey { get;}
        string BlkExpl { get; }
        string PriceFeed { get; }
        void SetUserInput();
    }
}
