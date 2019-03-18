using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Contestant
    {
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
            }
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
            }
        }
        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
            }
        }
        private string registrationNum;
        public string RegistrationNum
        {
            get => registrationNum;
            set
            {
                registrationNum = value;
            }
        }

        public Contestant(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        






    }
}
