using StickWar.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public class Healer : Support
    {
        public Healer(int teamNum)
        {
            this.health = 1;
            this.team = teamNum;
            this.isNull = false;
            this.isSupport = true;
            this.cost = 50;
            this.unitSymbol = "H";
        }
    }
}
