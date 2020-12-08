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
        //below are porperties not native to EtherScan JSON
        public string price;

        public long GetTimeStamp()
        {
            return long.Parse(timeStamp);
        }

        public string GetHash()
        {
            return hash;
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

        public string GetPrice()
        {
            return price;
        }

        public void SetPrice(string price)
        {
            this.price = price;
        }

        public string GetDateIso8601()
        {
            throw new NotImplementedException();
        }
    }
}
