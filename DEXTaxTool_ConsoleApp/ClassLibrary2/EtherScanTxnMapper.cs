using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;
using Newtonsoft.Json;
using Parser.EtherScanJSONDataObjs;
using Newtonsoft.Json.Linq;

namespace Parser
{
    /// <summary>
    /// Deserializes EtherScan JSON and outputs ITxn objects 
    /// </summary>
    public class EtherScanTxnMapper : ITxnMapper
    {

        public ITxn[] MapToTxn(TxnTypeEnum txnTypeEnum, string JsonStr)
        {
            //TODO:
            //Need to handle bettwe if unsuccessful at getting the account txn information
            //Need a better way to structure the classes and objects for deserializing
            JObject jObj = JObject.Parse(JsonStr);
            if (jObj["status"].ToString() == "0")
            {
                throw getErrorMessage(jObj);
            }
            switch (txnTypeEnum)
            {
                case TxnTypeEnum.Normal:
                    NormalTxnResponse normalTxnResponse = JsonConvert.DeserializeObject<NormalTxnResponse>(JsonStr);
                    return normalTxnResponse.result;
                case TxnTypeEnum.Erc20:
                    Erc20TxnResponse erc20TxnResponse = JsonConvert.DeserializeObject<Erc20TxnResponse>(JsonStr);
                    return erc20TxnResponse.result;
                case TxnTypeEnum.Internal:
                    InternalTxnResponse internalTxnResponse = JsonConvert.DeserializeObject<InternalTxnResponse>(JsonStr);
                    return internalTxnResponse.result;
            }
            throw new Exception("MapToTxn(): unrecognizable TxnTypeEnum. Can't deserialize");
        }
        private Exception getErrorMessage(JObject jObj)
        {
            return new Exception($"Problem with getting JSON from EtherScan \n Message : {jObj["message"]} Result: {jObj["result"]}");
        }

    }
}
