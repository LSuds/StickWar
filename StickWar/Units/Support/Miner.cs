using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public class Miner : Units.Support
    {
        public Miner(int teamNum)
        {
            this.health = 1;
            this.team = teamNum;
            this.isNull = false;
            this.isSupport = true;
            this.cost = 80;
            this.unitSymbol = "M"; // miner unit sym
        }
    }
}
