﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Winner : Contestant
    {

        public Winner(string firstName, string lastName, string email, string registration)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RegistrationNum = registration;
        }

        public override void PostWinner()
        {
            Console.WriteLine("Congratulations! You won the sweepstakes!");
        }
    }
}