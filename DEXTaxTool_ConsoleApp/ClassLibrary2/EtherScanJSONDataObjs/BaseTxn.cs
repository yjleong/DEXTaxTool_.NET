using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.EtherScanJSONDataObjs
{
    public abstract class BaseTxn : ITxn
    {
        public string blockNumber;
        public string timeStamp;
        public string hash;
        public string from;
        public string to;
        public string value;
        public string gas;
        public string input;
        public string contractAddress;
        public string gasUsed;

        public long GetTimeStamp()
        {
            return long.Parse(timeStamp);
        }

        public long GetHash()
        {
            return long.Parse(hash);
        }

        public string GetFromAddress()
        {
            return from;
        }

        public string GetToAddress()
        {
            return to;
        }

        public double GetValue()
        {
            return double.Parse(value);
        }

        abstract public string GetToken();
    }
}
