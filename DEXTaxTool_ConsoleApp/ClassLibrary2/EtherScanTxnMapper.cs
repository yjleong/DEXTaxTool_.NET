using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;
using Newtonsoft.Json;
using Parser.EtherScanJSONDataObjs;

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
            switch (txnTypeEnum)
            {
                case TxnTypeEnum.Normal:
                    NormalTxnResponse normalTxnResponse = JsonConvert.DeserializeObject<NormalTxnResponse>(JsonStr);
                    if (normalTxnResponse.status == "0")
                    {
                        throw getErrorMessage(JsonStr);
                    }
                    return normalTxnResponse.result;
                case TxnTypeEnum.Erc20:
                    Erc20TxnResponse erc20TxnResponse = JsonConvert.DeserializeObject<Erc20TxnResponse>(JsonStr);
                    if (erc20TxnResponse.status == "0")
                    {
                        throw getErrorMessage(JsonStr);
                    }
                    return erc20TxnResponse.result;
                case TxnTypeEnum.Internal:
                    InternalTxnResponse internalTxnResponse = JsonConvert.DeserializeObject<InternalTxnResponse>(JsonStr);
                    if (internalTxnResponse.status == "0")
                    {
                        throw getErrorMessage(JsonStr);
                    }
                    return internalTxnResponse.result;
            }
            throw new Exception("MapToTxn(): unrecognizable TxnTypeEnum. Can't deserialize");
        }
        private Exception getErrorMessage(string JsonStr)
        {
            var definition = new { status = "", message = "", result = "" };
            var errorJson = JsonConvert.DeserializeAnonymousType(JsonStr, definition);
            return new Exception($"Problem with getting JSON from EtherScan \n Message : {errorJson.message} Result: {errorJson.result}");
        }

    }
}
