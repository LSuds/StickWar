using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StickWar
{
    class Reader
    {
        private static Thread inputThread;
        private static AutoResetEvent getInput, gotInput;
        private static int input;

        static Reader()
        {
            getInput = new AutoResetEvent(false);
            gotInput = new AutoResetEvent(false);
            inputThread = new Thread(reader);
            inputThread.IsBackground = true;
            inputThread.Start();
        }

        private static void reader()
        {
            while (true)
            {
                getInput.WaitOne();
                ConsoleKeyInfo inChar = Console.ReadKey();
                if (char.IsDigit(inChar.KeyChar))
                {
                    input = int.Parse(inChar.KeyChar.ToString());
                }
                else
                    input = 0;
                gotInput.Set();
            }
        }

        // omit the parameter to read a line without a timeout
        public static int ReadLine(int timeOutMillisecs = Timeout.Infinite)
        {
            getInput.Set();
            bool success = gotInput.WaitOne(timeOutMillisecs);
            if (success)
                return input;
            else
                return 0;
        }
    }
}
