using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public class Unit
    {
        public int health;
        public int team;
        public string unitSymbol;
        public bool isNull;
        public bool isSupport;
        public int cost;
        public Unit()
        {
            isSupport = false;
            cost = 0;
            health = 0;
            team = 0;
            unitSymbol = "     ";
            isNull = true;
        }
    }
}
