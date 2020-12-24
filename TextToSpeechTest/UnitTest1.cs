using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextSpeech;

namespace TextToSpeechTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TextSpeaker test = new TextSpeaker();
            int rate = test.Rate;
            Assert.AreEqual(1, rate, 0);           
            
        }
    }
}
