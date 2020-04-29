using StickWar.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickWar
{
    public static class GameBoard
    {
        //*********************CONSTANTS***********************
        private const double HealPerTick = .2;
        private const int MinerGeneratePerTick = 5;

        private static Unit[] PlayingField = new Unit[10] {
            new Unit(),new Unit(),new Unit(),
            new Unit(),new Unit(),new Unit(),
            new Unit(),new Unit(),new Unit(),
            new Unit()};

        private static Support[] Base1 = new Support[4]
        {
            new Miner(1),new Support(),new Support(), new Support()
        };

        private static Support[] Base2 = new Support[4]
        {
            new Miner(2),new Support(),new Support(), new Support()
        };

        public static int ReDraw()
        {
            GenerateIncome();
            GenerateHealth();
            MovePlayer1();
            MovePlayer2();
            DrawField();
            return CheckWin();
        }
        public static void AddUnit(Support newU)
        {
            if (newU.team == 1 && (Player1.money - newU.cost >= 0))
            {
                if (newU.isSupport && Player1.healerCount + Player1.minerCount < 4)
                {
                    Base1[Player1.healerCount + Player1.minerCount] = newU;
                    Player1.money = Player1.money - newU.cost;
                    if (newU.GetType() == typeof(Miner))
                    {
                        Player1.minerCount++;
                    }
                    else
                        Player1.healerCount++;
                    DrawField();
                }
            }
            else if (newU.team == 2 && (Player2.money - newU.cost >= 0))
            {
                if (newU.isSupport && Player2.healerCount + Player2.minerCount < 4)
                {
                    Base2[Player2.healerCount + Player2.minerCount] = newU;
                    Player2.money = Player2.money - newU.cost;
                    if (newU.GetType() == typeof(Miner))
                    {
                        Player2.minerCount++;
                    }
                    else
                        Player2.healerCount++;
                    DrawField();
                }
            }
        }//Polymorphism
        public static void AddUnit(Unit newU)
        {
            if (newU.team == 1 && (Player1.money - newU.cost >= 0))
            {
                if (PlayingField[0].isNull)
                {
                    PlayingField[0] = newU;
                    Player1.money = Player1.money - newU.cost;
                    DrawField();
                }
            }
            else if (newU.team == 2 && (Player2.money - newU.cost >= 0))
            {
                if (PlayingField[9].isNull)
                {
                    PlayingField[9] = newU;
                    Player2.money = Player2.money - newU.cost;
                    DrawField();
                }
            }
        }//Polymorphism
        private static void GenerateHealth()
        {
            Player1.health = Player1.health + (decimal)(Player1.healerCount * HealPerTick);
            Player2.health = Player2.health + (decimal)(Player2.healerCount * HealPerTick);
        }
        private static void GenerateIncome()
        {
            Player1.money = Player1.money + Player1.minerCount * MinerGeneratePerTick + (1 - Player1.minerCount);
            Player2.money = Player2.money + Player2.minerCount * MinerGeneratePerTick + (1 - Player2.minerCount);
        }
        private static void DrawField()
        {
            int i;
            Console.Clear();
            Console.WriteLine("\n1-Peasant                                         (cost: 20)                                      5-Peasant");
            Console.WriteLine("2-Tank                                            (cost: 50)                                      6-Tank");
            Console.WriteLine("3-Miner                                           (cost: 80)                                      7-Miner");
            Console.WriteLine("4-Healer                                          (cost: 50)                                      8-Healer");
            Console.WriteLine("\n===========================================================================================================");
            Console.WriteLine("\n===========================================================================================================\n");
            Console.ForegroundColor = ConsoleColor.Blue;//player 1 color
            Console.Write(Player1.name.PadRight(10, ' '));
            Console.ResetColor();
            Console.Write("                                                                                  ");
            Console.ForegroundColor = ConsoleColor.Green;//player 2 color
            Console.Write(Player2.name.PadRight(10, ' ') + "\n\n");
            Console.ResetColor();

            for (i = 0; i < 4; i++)//base1
            {
                Console.Write("[" + Base1[i].unitSymbol + "] ");
            }
            Console.Write(":::");

            for (i = 0; i < 10; i++)//field
            {
                if (PlayingField[i].team == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("[" + PlayingField[i].unitSymbol + "]");
                }
                else if (PlayingField[i].team == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[" + PlayingField[i].unitSymbol + "]");
                }
                else
                {
                    Console.Write("[" + PlayingField[i].unitSymbol + "]");
                }
                Console.ResetColor();
            }

            Console.Write(":::");
            for (i = 0; i < 4; i++)//base2
            {
                Console.Write("[" + Base2[i].unitSymbol + "] ");
            }


            Console.WriteLine();

            if (Player1.health < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Health:" + Player1.health.ToString().PadRight(3, ' '));
                Console.ResetColor();
            }
            else
            {
                Console.Write("Health:" + Player1.health.ToString().PadRight(3, ' '));
            }

            Console.Write("                                                                                  ");

            if (Player2.health < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Health:" + Player2.health.ToString().PadRight(3, ' '));
                Console.ResetColor();
            }
            else
            {
                Console.Write("Health:" + Player2.health.ToString().PadRight(3, ' '));
            }

            Console.WriteLine("\nMoney:" + Player1.money.ToString().PadRight(3, ' ') + "                                                                                   " + "Money:" + Player2.money.ToString().PadLeft(3, ' '));//players health
        }
        internal static void CreateUnit(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        Peasant newU = new Peasant(1);
                        AddUnit(newU);
                        break;
                    }
                case 2:
                    {
                        Tank newU = new Tank(1);
                        AddUnit(newU);
                        break;
                    }
                case 3:
                    {
                        Miner newU = new Miner(1);
                        AddUnit(newU);
                        break;
                    }
                case 4:
                    {
                        Healer newU = new Healer(1);
                        AddUnit(newU);
                        break;
                    }
                case 5:
                    {
                        Peasant newU = new Peasant(2);
                        AddUnit(newU);
                        break;
                    }
                case 6:
                    {
                        Tank newU = new Tank(2);
                        AddUnit(newU);
                        break;
                    }
                case 7:
                    {
                        Miner newU = new Miner(2);
                        AddUnit(newU);
                        break;
                    }
                case 8:
                    {
                        Healer newU = new Healer(2);
                        AddUnit(newU);
                        break;
                    }
                default:
                    break;
            }
        }
        private static void MovePlayer1()
        {
            int i;
            for (i = 9; i >= 0; i--)
            {
                if (PlayingField[i].isNull == false && PlayingField[i].team == 1)
                {
                    if (i == 9)
                    {
                        var newUnit = new Unit();
                        Player2.health = Player2.health - PlayingField[i].health;
                        PlayingField[i] = newUnit;
                    }
                    else if (PlayingField[i + 1].team == 2)//check for combat
                    {
                        if (PlayingField[i + 1].health > PlayingField[i].health)//Player 2 wins battle
                        {
                            PlayingField[i + 1].health = PlayingField[i + 1].health - PlayingField[i].health;
                            PlayingField[i] = new Unit();
                        }
                        else if (PlayingField[i + 1].health < PlayingField[i].health)//Player 1 wins battle
                        {
                            PlayingField[i].health = PlayingField[i].health - PlayingField[i + 1].health;
                            PlayingField[i + 1] = PlayingField[i];
                            PlayingField[i] = new Unit();
                        }
                        else
                        {
                            PlayingField[i] = new Unit();
                            PlayingField[i + 1] = new Unit();
                        }
                    }
                    else
                    {
                        var newUnit = new Unit();

                        PlayingField[i + 1] = PlayingField[i];
                        PlayingField[i] = newUnit;
                    }
                }
            }
        }
        private static void MovePlayer2()
        {
            {
                int i;
                for (i = 0; i < 10; i++)
                {
                    if (PlayingField[i].isNull == false && PlayingField[i].team == 2)
                    {
                        if (i == 0)
                        {
                            var newUnit = new Unit();
                            Player1.health = Player1.health - PlayingField[i].health;
                            PlayingField[i] = newUnit;
                        }
                        else if (PlayingField[i - 1].team == 1)//check for combat
                        {
                            if (PlayingField[i - 1].health > PlayingField[i].health)//Player 1 wins battle
                            {
                                PlayingField[i - 1].health = PlayingField[i - 1].health - PlayingField[i].health;
                                PlayingField[i] = new Unit();
                            }
                            else if (PlayingField[i - 1].health < PlayingField[i].health)//Player 2 wins battle
                            {
                                PlayingField[i].health = PlayingField[i].health - PlayingField[i - 1].health;
                                PlayingField[i - 1] = PlayingField[i];
                                PlayingField[i] = new Unit();
                            }
                            else
                            {
                                PlayingField[i] = new Unit();
                                PlayingField[i - 1] = new Unit();
                            }
                        }
                        else
                        {
                            var newUnit = new Unit();

                            PlayingField[i - 1] = PlayingField[i];
                            PlayingField[i] = newUnit;
                        }
                    }
                }
            }
        }
        private static int CheckWin()
        {
            if (Player1.health <= 0 && Player2.health <= 0)
            {
                return 3;
            }
            else if (Player1.health <= 0)
            {
                return 2;
            }
            else if (Player2.health <= 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
