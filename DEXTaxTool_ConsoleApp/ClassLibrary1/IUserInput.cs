using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Input
{
    public interface IUserInput
    {
        string EthAddress { get; }
        string ApiKey { get;}
        void SetUserInput();
    }
}
