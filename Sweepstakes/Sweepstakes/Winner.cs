using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Winner : Contestant
    {

        public Winner(string firstName, string lastName, string email, string registration) :base(firstName,lastName,email,registration)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RegistrationNum = registration;
        }

        public override void Notify(Contestant winner)
        {
            Console.WriteLine("Congratulations, {0} {1}! You won the sweepstakes! Please check your email!\n", winner.FirstName, winner.LastName);
            //send email from here.
        }
    }
}
