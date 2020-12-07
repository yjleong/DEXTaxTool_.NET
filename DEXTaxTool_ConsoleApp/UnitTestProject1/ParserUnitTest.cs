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
            var txns = new ITxn[0];
            txns = ethScanTxnMapper.MapToTxn(TxnTypeEnum.Normal,contents);
            //Might be better to compare to a mock ITxn[]?
            Assert.IsTrue(txns.Length != 0);
            
        }

        [TestMethod]
        public void EtherScanTxnMapper_Successful_Erc20TxnMap()
        {


        }

        [TestMethod]
        public void EtherScanTxnMapper_Successful_InternalTxnMap()
        {


        }


    }
}
