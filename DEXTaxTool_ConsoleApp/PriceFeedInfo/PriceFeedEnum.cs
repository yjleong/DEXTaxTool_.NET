using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceFeedInfo
{
        //Supproted price feed 
        // TODO: 
        // Get enums from DB in future
        public enum PriceFeedEnum
        {
            Coinbase
        }

        //TODO: Find better place for this, its inherently bound to the enum though
        public class PriceFeedEnumDict
        {
            public Dictionary<string, PriceFeedEnum> EnumDict;
            public PriceFeedEnumDict()
            {
                var enumDict = new Dictionary<string, PriceFeedEnum>();
                foreach (PriceFeedEnum priceFeedEnum in Enum.GetValues(typeof(PriceFeedEnum)))
                {
                    enumDict.Add(priceFeedEnum.ToString(), priceFeedEnum);
                }
                EnumDict = enumDict;
            }
        }
    }

