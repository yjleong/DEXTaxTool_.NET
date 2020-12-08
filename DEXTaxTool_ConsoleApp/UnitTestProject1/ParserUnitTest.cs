using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using BlockExplorerInfo;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class ParserTests
    {
        //TODO: add test for bad inputs? like bad URL, API key and address?
        [TestMethod]
        public void EtherScanTxnRequester_Successful_Connection()
        {
            var blkExplUrl = new BlockExplorerURL();
            Dictionary <TxnTypeEnum,string> etherScanUrl = blkExplUrl.BlockExplorerURLDict[BlockExplorerEnum.EtherScan];
            var stubUserInput = new TestUserInput(@"..\..\EtherScanJSON\UserInputEtherScan.json");
            stubUserInput.SetUserInput();
            var ethScanTxnRequester = new EtherScanTxnRequester(stubUserInput, etherScanUrl);
            var result = ethScanTxnRequester.GetTxnsAsync(TxnTypeEnum.Normal).Result;
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void EtherScanTxnMapper_Successful_NormalTxnMap()
        {
            var ethScanTxnMapper = new EtherScanTxnMapper();
            string contents;
            using (var file = File.OpenText(@"..\..\EtherScanJSON\EtherScanNormalTxns.json"))
            {
               contents = file.ReadToEnd();
            }
            ITxn[] txns;
            txns = ethScanTxnMapper.MapToTxn(TxnTypeEnum.Normal,contents);
            //Might be better to compare to a mock ITxn[]? 
            Assert.IsNotNull(txns);
        }

        [TestMethod]
        public void EtherScanTxnMapper_Successful_Erc20TxnMap()
        {
            var ethScanTxnMapper = new EtherScanTxnMapper();
            string contents;
            using (var file = File.OpenText(@"..\..\EtherScanJSON\EtherScanErc20Txns.json"))
            {
                contents = file.ReadToEnd();
            }
            ITxn[] txns;
            txns = ethScanTxnMapper.MapToTxn(TxnTypeEnum.Erc20, contents);
            //Might be better to compare to a mock ITxn[]?
            Assert.IsNotNull(txns);
        }

        [TestMethod]
        public void EtherScanTxnMapper_Successful_InternalTxnMap()
        {
            var ethScanTxnMapper = new EtherScanTxnMapper();
            string contents;
            using (var file = File.OpenText(@"..\..\EtherScanJSON\EtherScanInternalTxns.json"))
            {
                contents = file.ReadToEnd();
            }
            ITxn[] txns;
            txns = ethScanTxnMapper.MapToTxn(TxnTypeEnum.Erc20, contents);
            //Might be better to compare to a mock ITxn[]?
            Assert.IsNotNull(txns);
        }

        [TestMethod]
        public void EtherScanTxnMapper_ErrorJson_BadStatus()
        {
            try
            {
                var ethScanTxnMapper = new EtherScanTxnMapper();
                string contents;
                using (var file = File.OpenText(@"..\..\EtherScanJSON\EtherScanBadStatus.json"))
                {
                    contents = file.ReadToEnd();
                }
                ITxn[] txns;
                txns = ethScanTxnMapper.MapToTxn(TxnTypeEnum.Normal, contents);
                //fail case if MapToTxn does not throw an exception
                throw new Exception();
            }
            catch (Exception e)
            {
                //TODO:
                //Need to handle this exception better at class level and with this case, shouldn't be checking strings and should be handling exception class itself
                Assert.IsTrue(e.Message.Contains("Problem with getting JSON from EtherScan"));
            }
        }
        [TestMethod]
        public void EtherScanTxnMapper_ErrorJson_RateLimit_Or_DefaultApiKey()
        {
            try
            {
                var ethScanTxnMapper = new EtherScanTxnMapper();
                string contents;
                using (var file = File.OpenText(@"..\..\EtherScanJSON\EtherScanRateBlankOrDefaultApiKey.json"))
                {
                    contents = file.ReadToEnd();
                }
                ITxn[] txns;
                txns = ethScanTxnMapper.MapToTxn(TxnTypeEnum.Normal, contents);
                //fail case if MapToTxn does not throw an exception
                throw new Exception();
            }
            catch (Exception e)
            {
                //TODO:
                //Need to handle this exception better at class level and with this case, shouldn't be checking strings and should be handling exception class itself
                Assert.IsTrue(e.Message.Contains("OK-Missing/Invalid API Key, rate limit of 1/5sec applied"));
            }
        }
        [TestMethod]
        [Ignore]
        public void TxnParser_GetTxnObjs_Success()
        {
            //Think of how to test it. GetTxnObjs basically helps pass between objects to TxnRequester and TxnMapper and outputs the results of both as a Dictionary
            //Mock up Dictionary return and compare it to output? 

            //ITxnRequester stubTxnRequester = new ...;
            //ITxnMapper stubTxnMapper = new ...;
            //var txnParser = new TxnParser(stubTxnRequester, stubTxnMapper);
        }
    }
}
