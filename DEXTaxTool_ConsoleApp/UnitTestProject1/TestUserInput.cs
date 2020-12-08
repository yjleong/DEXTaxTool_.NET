using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;
using UserInput;
using System.IO;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1
{
    public class TestUserInput :IUserInput
    {

        private string fileName;
        private string apiKey;
        private string ethAddress;
        private string blkExpl;
        private string priceFeed;
        public TestUserInput(string fileName)
        {
            this.fileName = fileName;
        }
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
        }

        public string BlkExpl
        {
            get
            {
                return blkExpl;
            }
        }

        public string EthAddress
        {
            get
            {
                return ethAddress;
            }
        }

        public string PriceFeed
        {
            get
            {
                return priceFeed;
            }
        }

        public void SetUserInput()
        {
            using (var file = File.OpenText(fileName))
            {
                string contents = file.ReadToEnd();
                JObject jObj = JObject.Parse(contents);
                apiKey = jObj["apiKey"].ToString();
                ethAddress = jObj["ethAddress"].ToString() ;
                blkExpl = jObj["blkExpl"].ToString();
            }
        }
    }
}
