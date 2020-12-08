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
        string GetHash();
        string GetFromAddress();
        string GetToAddress();
        double GetValue();
        string GetToken();
        string GetPrice();
        void SetPrice(string price);
        string GetDateIso8601(long addDays = 0);
    }
}
