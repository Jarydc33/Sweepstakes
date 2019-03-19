using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class MarketingFirm
    {
        List<Contestant> allContestants;
        Sweepstakes CurrentSweepstakes;
        Sweepstakes CarSweepstakes;
        Sweepstakes VacationSweepstakes;
        ISweepstakesManager _manager;
        int registrationCounter;

        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;
            CarSweepstakes = new Sweepstakes("New Car Giveaway!");
            VacationSweepstakes = new Sweepstakes("Trip to Hawaii Giveaway!");
            manager.InsertSweepstakes(CarSweepstakes);
            manager.InsertSweepstakes(VacationSweepstakes);
            CurrentSweepstakes = manager.GetSweepstakes();
            allContestants = new List<Contestant>();
            registrationCounter = 0;
            GetEntries();
            
        }

        public void GetEntries()
        {
            string[] newEntry = new string[3];
            newEntry = UI.EnterInfo();
            string registrationNumber = CreateRegistrationNumber();
            allContestants.Add(new Contestant(newEntry[0], newEntry[1], newEntry[2], registrationNumber));
            CurrentSweepstakes.RegisterContestant(allContestants[registrationCounter]);
            registrationCounter++;
            GetMoreEntries();
        }

        public void GetMoreEntries()
        {
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
                    UI.IncorrectInput();
                    GetMoreEntries();
                    break;
            }
        }

        public void PickWinner()
        {
            string winner = CurrentSweepstakes.PickWinner(); //name of winner
            Contestant ContestantWinner = FindWinner(winner);
            CurrentSweepstakes.PrintContestantInfo(ContestantWinner);            
        }

        public string CreateRegistrationNumber()
        {
            int registration = registrationCounter;
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