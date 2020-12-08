using PriceFeedInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class PriceFeedConsoleInput : IPriceFeedUserInput
    {
        private string priceFeed;
        private Dictionary<string, PriceFeedEnum> enumDict;
        public string PriceFeed
        {
            get
            {
                return priceFeed;
            }
        }

        //public PriceFeedConsoleInput(Dictionary<string, PriceFeedEnum> enumDict)
        //{
        //    this.enumDict = enumDict;
        //}

        public void SetUserInput()
        {

        }
    }
}
