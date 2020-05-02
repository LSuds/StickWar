using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public static class Player2
    {
        private static decimal _health;
        private static int _minerCount;
        private static int _healerCount;
        public static decimal health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value >= 100)
                {
                    _health = 100;
                }
                else
                    _health = value;
            }
        }//Encapsulation
        public static int minerCount
        {
            get
            {
                return _minerCount;
            }
            set
            {
                if (value > 4 - _healerCount)
                {
                    _minerCount = minerCount;
                }
                else
                {
                    _minerCount = value;
                }
            }
        }//Encapsulation
        public static int healerCount
        {
            get
            {
                return _healerCount;
            }
            set
            {
                if (value > 4 - _minerCount)
                {
                    _healerCount = healerCount;
                }
                else
                {
                    _healerCount = value;
                }
            }
        }//Encapsulation
        public static string name;
        public static int money;

        static Player2()
        {
            healerCount = 0;
            minerCount = 1;
            health = 20;
            money = 50;
            name = "No Name";
        }
    }
}
