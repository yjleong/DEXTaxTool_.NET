using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxnParser
{
    public interface ITxnMapper
    {
        string MapToTxn(string str);
    }
}
