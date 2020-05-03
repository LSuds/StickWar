using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StickWarTests
{
    [TestClass]
    public class UnitsPlayer2
    {
        [TestMethod]
        public void TestPeasant()
        {
            StickWar.Player2.money = 200;
            StickWar.GameBoard.CreateUnit(5);
            StickWar.Peasant newP = new StickWar.Peasant(2);
            Assert.AreEqual(StickWar.GameBoard.PlayingField[0].GetType(), newP.GetType());
        }
        [TestMethod]

        public void TestHealer()
        {
            StickWar.Player2.money = 200;
            StickWar.GameBoard.CreateUnit(8);
            StickWar.Healer newP = new StickWar.Healer(2);
            Assert.AreEqual(StickWar.GameBoard.Base2[1].GetType(), newP.GetType());
        }
    }
}
