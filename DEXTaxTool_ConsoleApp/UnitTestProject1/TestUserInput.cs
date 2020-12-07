using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockExplorerInfo;
using UserInput;
using System.IO;

namespace UnitTestProject1
{
    public class TestUserInput :IUserInput
    {
        public TestUserInput(string fileName)
        {
            using (var file = File.OpenText(fileName))
            {
                string contents = file.ReadToEnd();
                List<TestKey> keys = JsonConvert.DeserializeObject<List<TestKey>>(contents);
                if (injectedErrors != null && injectedErrors.Any())
                {
                    foreach (var key in keys)
                    {
                        key._injectedErrors = injectedErrors;
                    }
                }
                KeyList = keys.Cast<IKeyData>().ToList();
            }
        }
        private string apiKey;
        private string ethAddress;
        private BlockExplorerEnum blkExpl;

        public string ApiKey
        {
            get
            {
                return apiKey;
            }
        }

        public BlockExplorerEnum BlkExpl
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

        public void SetUserInput()
        {
            
        }
    }
}
