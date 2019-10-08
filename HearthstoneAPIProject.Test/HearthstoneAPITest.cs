using System;
using NUnit.Framework;
using HearthstoneAPIProject;
using Newtonsoft.Json.Linq;

namespace HearthstoneAPIProject.Test
{
    [TestFixture()]
    public class GetSingleHeathStoneAPIItemTest
    {
        HearthstoneData hd = new HearthstoneData();
        public GetSingleHeathStoneAPIItemTest()
        {
            hd.GetSingleHeathStoneAPIItem("https://omgvamp-hearthstone-v1.p.rapidapi.com/info");
        }
        [Test()]
        public void ContentTypeTest()
        {
            Assert.AreEqual("Content-Type=application/json", hd.response.Headers[2].ToString());
        }
        [Test()]
        public void PatchVersionTest()
        {
            Assert.AreEqual("15.2.2.34104", hd.HearthStoneAPIItem["patch"].ToString());
        }
        [Test()]
        public void CheckClassItemTest()
        {
            Assert.AreEqual("Druid", hd.HearthStoneAPIItem["classes"][1].ToString()); //classes is the KEY. (Is the property (get, set))
        }
        [Test()]
        public void CheckSetsItemTest()
        {
            Assert.AreEqual("The Witchwood", hd.HearthStoneAPIItem["sets"][15].ToString());
        }
        [Test()]
        public void CheckStandardItemTest()
        {
            Assert.AreEqual("Classic", hd.HearthStoneAPIItem["standard"][1].ToString());
        }
        [Test()]
        public void CheckWildItemTest()
        {
            Assert.AreEqual("The League of Explorers", hd.HearthStoneAPIItem["wild"][8].ToString());
        }
        [Test()]
        public void CheckFactionsItemTest()
        {
            Assert.AreEqual("Alliance", hd.HearthStoneAPIItem["factions"][1].ToString());
        }
        [Test()]
        public void CheckQualitiesItemTest()
        {
            Assert.AreEqual("Rare", hd.HearthStoneAPIItem["qualities"][2].ToString());
        }
        [Test()]
        public void CheckRacesItemTest()
        {
            Assert.AreEqual("Pirate", hd.HearthStoneAPIItem["races"][6].ToString());
        }
        [Test()]
        public void CheckLocalesItemTest()
        {
            Assert.AreEqual("enUS", hd.HearthStoneAPIItem["locales"][2].ToString());
        }
        [Test()]
        public void CheckStatus()
        {
            Assert.AreEqual("OK", hd.response.StatusCode.ToString());
        }
        [Test()]
        public void CheckFirstHeaderExistenceAndItsValue()
        {
            Assert.AreEqual("pragma=no-cache", hd.response.Headers[0].ToString());
        }
        [Test()]
        public void CheckEleventhHeaderExistenceAndItsValue()
        {
            Assert.AreEqual("transfer-encoding=chunked", hd.response.Headers[10].ToString());
        }
        [Test()]
        public void CheckTwelfthHeaderExistenceAndItsValue()
        {
            Assert.AreEqual("Connection=keep-alive", hd.response.Headers[11].ToString());
        }
        [Test()]
        public void CheckHeaderNumber()
        {
            Assert.AreEqual("12", hd.response.Headers.Count.ToString());
        }
    }
}
