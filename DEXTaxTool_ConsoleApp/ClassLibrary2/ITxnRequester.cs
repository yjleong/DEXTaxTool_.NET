using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxnParser
{
    public interface ITxnRequester
    {
        string GetTxns(string URI);
    }
}
