using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class MarketingFirm
    {
        List<Contestant> allContestants;
        Sweepstakes Sweepstakes;
        int registrationCounter;

        public MarketingFirm()
        {
            allContestants = new List<Contestant>();
            Sweepstakes = new Sweepstakes("New Car Giveaway!");
            registrationCounter = 1;
            GetEntries();
            
        }

        public void GetEntries()
        {
            string[] newEntry = new string[4];
            newEntry = UI.EnterInfo();
            newEntry[3] = CreateRegistrationNumber();
            allContestants.Add(new Contestant(newEntry[0], newEntry[1], newEntry[2], newEntry[3]));
            string enterMore = UI.EnterMore();

            switch (enterMore)
            {
                case "yes":
                    GetEntries();
                    break;

                case "no":
                    Environment.Exit(0);
                    break;

                default:
                    
                    break;
            }
        }

        public string CreateRegistrationNumber()
        {
            int registration = registrationCounter;
            registrationCounter++;
            string stringRegistration = registration.ToString();
            return stringRegistration;
        }
        public void StoreRegistrationNumbers(int registration)
        {
            //BST here
        }
    }
}