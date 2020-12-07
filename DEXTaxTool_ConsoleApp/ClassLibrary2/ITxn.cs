using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Defines methods 
    /// </summary>
    public interface ITxn
    {
        long GetTimeStamp();
        long GetHash();
        string GetFromAddress();
        string GetToAddress();
        double GetValue();
        string GetToken();
        
    }
}
