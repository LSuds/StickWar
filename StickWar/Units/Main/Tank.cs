using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public class Tank : Unit
    {
        public Tank(int teamNum)
        {

            this.health = 5;
            this.team = teamNum;
            this.isNull = false;
            this.cost = 50;

            if (teamNum == 1)
            {
                this.unitSymbol = " T=- ";
            }
            else
            {
                this.unitSymbol = " -=T ";
            }
        }
    }
}
