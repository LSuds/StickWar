using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public class Peasant : Unit
    {
        public Peasant(int teamNum)
        {
            
            this.health = 2;
            this.team = teamNum;
            this.isNull = false;
            this.cost = 20;
            
            if(teamNum==1)
            {
                this.unitSymbol = " >-- ";
            }
            else
            {
                this.unitSymbol = " --< ";
            }
        }
    }
}
