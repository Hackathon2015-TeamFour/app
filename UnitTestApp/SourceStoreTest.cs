using System;
using App.DLL.Data;
using App.GUI.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestApp
{
    [TestClass]
    public class SourceStoreTest
    {
        /// <summary>
        /// 4,SIX Swiss Exchange
        /// 176,UBS Investment Bank
        /// 178,Zurcher Kantonalbank Foreign Exchange
        /// 180,Commerzbank Frankfurt
        /// 310,Dow Jones Index Chicago
        /// 717,Osaka Stock Exchange Evening Session
        /// 830,XETRA Deutsche Börsen-Indices
        /// 2979,ICAP Plc London Premium Spot Forex
        /// 3215,Tullett Prebon Information 
        /// 3250,ICAP Plc London Foreign Exchange
        /// </summary>

        [TestMethod]
        public void SingleAddValue()
        {
            var store = CreateSource("ubs");
            var timestamp = DateTime.Now;
            store.AddValue(42.23f, timestamp);
            var lastEntry = store.GetLastEntry();
            Assert.AreEqual(timestamp, lastEntry.Value);
        }
        [TestMethod]
        public void AddAndGetSecondValue()
        {
            var store = CreateSource("ubs");
            var timestamp = DateTime.Parse("2014-01-01");
            store.AddValue(42.23f, timestamp);
            var timestamp2nd = DateTime.Now;
            store.AddValue(12.34f, timestamp2nd);
            var lastEntry = store.GetLastEntry();
            Assert.AreEqual(timestamp2nd, lastEntry.Value);
            Assert.AreEqual(12.34f, lastEntry.Key);
        }

        private static SourceStore CreateSource(string sourceDescription)
        {
            switch (sourceDescription)
            {
                case "ubs":
                    var marketCode = new market_code();
                    marketCode.Exchange_or_Contributor_Name = "UBS Investment Bank";
                    market_code.marketCode = 176;
                    return new SourceStore(marketCode);
                default:
                    return null;
            }

            
        }
    }
}
