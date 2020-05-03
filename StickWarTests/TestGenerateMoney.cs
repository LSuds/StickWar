using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StickWarTests
{
    [TestClass]
    public class TestGenerateMoney
    {
        [TestMethod]
        public void TestP1Income()
        {
            StickWar.Player1.money = 0;
            StickWar.GameBoard.ReDraw();
            Assert.AreEqual(StickWar.Player1.money,5);
        }
        [TestMethod]

        public void TestP2Income()
        {
            StickWar.Player2.money = 0;
            StickWar.GameBoard.ReDraw();
            Assert.AreEqual(StickWar.Player2.money, 5);
        }
    }
}
