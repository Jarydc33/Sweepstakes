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
            registrationCounter = 0;
            GetEntries();
            
        }

        public void GetEntries()
        {
            string[] newEntry = new string[4];
            newEntry = UI.EnterInfo();
            string registrationNumber = CreateRegistrationNumber();
            allContestants.Add(new Contestant(newEntry[0], newEntry[1], newEntry[2], registrationNumber));
            Sweepstakes.RegisterContestant(allContestants[0]);
            string enterMore = UI.EnterMore();

            switch (enterMore)
            {
                case "yes":
                    GetEntries();
                    break;

                case "no":
                    PickWinner();
                    break;

                default:
                    
                    break;
            }
        }

        public void PickWinner()
        {
            string winner = Sweepstakes.PickWinner(); //name of winner
            Contestant ContestantWinner = FindWinner(winner);
            UI.PrintWinner(Sweepstakes.Name, ContestantWinner.FirstName, ContestantWinner.LastName, ContestantWinner.Email);
        }

        public string CreateRegistrationNumber()
        {
            int registration = registrationCounter;
            registrationCounter++;
            string stringRegistration = registration.ToString();
            return stringRegistration;
        }

        public Contestant FindWinner(string winner)
        {
            foreach(Contestant contestant in allContestants)
            {
                if (winner == contestant.FirstName + " " + contestant.LastName)
                {
                    return contestant;
                }                
            }
            return FindWinner(winner);
        }
    }
}