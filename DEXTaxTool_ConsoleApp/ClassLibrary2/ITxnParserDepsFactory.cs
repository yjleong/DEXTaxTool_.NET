using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    //need renaming
    public interface ITxnParserDepsFactory
    {
        ITxnMapper GetTxnMapper();
        ITxnRequester GetTxnRequester();
    }
}
