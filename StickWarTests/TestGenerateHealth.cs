using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StickWarTests
{
    [TestClass]
    public class TestGenerateHealth
    {
        [TestMethod]
        public void TestP1Health()
        {
            StickWar.Player1.health = 20;
            StickWar.GameBoard.CreateUnit(4);
            StickWar.GameBoard.ReDraw();
            decimal testH = Convert.ToDecimal(20.2);
            Assert.AreEqual(StickWar.Player1.health, testH);
        }
        [TestMethod]

        public void TestP2Health()
        {
            StickWar.Player2.health = 20;
            StickWar.GameBoard.CreateUnit(8);
            StickWar.GameBoard.ReDraw();
            decimal testH = Convert.ToDecimal(20.2);
            Assert.AreEqual(StickWar.Player2.health, testH);
        }
    }
}
