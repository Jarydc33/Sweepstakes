﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public static class UI
    {
        public static string[] EnterInfo()
        {
            string[] userInfo = new string[3];
            Console.WriteLine("Please enter your first name: ");
            userInfo[0] = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            userInfo[1] = Console.ReadLine();
            Console.WriteLine("Please enter your email address: ");
            userInfo[2] = Console.ReadLine();

            return userInfo;
        }

        public static string ChooseInterface()
        {
            Console.WriteLine("Would you like to use Stack or Queue?");
            return Console.ReadLine();
        }
    }
}


    