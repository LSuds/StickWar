using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StickWarTests
{
    [TestClass]
    public class UnitsPlayer1
    {
        [TestMethod]
        public void TestPeasant()
        {
            StickWar.Player1.money = 200;
            StickWar.GameBoard.CreateUnit(1);
            StickWar.Peasant newP = new StickWar.Peasant(1);
            Assert.AreEqual(StickWar.GameBoard.PlayingField[0].GetType(), newP.GetType());
        }
        [TestMethod]

        public void TestHealer()
        {
            StickWar.Player1.money = 200;
            StickWar.GameBoard.CreateUnit(4);
            StickWar.Healer newP = new StickWar.Healer(1);
            Assert.AreEqual(StickWar.GameBoard.Base1[1].GetType(), newP.GetType());
        }
    }
}
