using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public static class UI
    {
        public static string EnterInfo(string infoNeeded)
        {
            string userInfo;
            Console.WriteLine("Please enter your {0}: ", infoNeeded);
            userInfo = Console.ReadLine();

            return userInfo;
        }

        public static string ChooseInterface()
        {
            Console.WriteLine("Would you like to use Stack or Queue?");
            return Console.ReadLine();
        }
    }
}


    