using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    //need renaming
    public interface IMapper_RequesterFactory
    {
        ITxnMapper GetTxnMapper();
        ITxnRequester GetTxnRequester();
    }
}
