﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public static class Player2
    {
        public static decimal health;
        public static string name;
        public static int money;
        public static int minerCount;
        public static int healerCount;

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