using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sweepstakes
{
    public class MarketingFirm
    {
        List<IContestant> allContestants;
        Sweepstakes CurrentSweepstakes;
        ISweepstakesManager _manager;
        int registrationCounter;

        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;
            allContestants = new List<IContestant>();
            registrationCounter = 0;
            
        }

        public void InsertNewSweepstakes(Sweepstakes sweepstakesToInsert)
        {
            _manager.InsertSweepstakes(sweepstakesToInsert);
        }

        public void GetNewSweepstakes()
        {
            CurrentSweepstakes = _manager.GetSweepstakes();
        }

        public void GetEntries()
        {
            string[] newEntry = new string[3];
            newEntry = UI.EnterInfo();
            string registrationNumber = CreateRegistrationNumber();
            allContestants.Add(new Contestant(newEntry[0], newEntry[1], newEntry[2], registrationNumber));
            CurrentSweepstakes.RegisterContestant(allContestants[registrationCounter]);
            registrationCounter++;
        }

        public void PickWinner()
        {
            string winner = CurrentSweepstakes.PickWinner(); //name of winner
            Contestant ContestantWinner = FindWinner(winner);
            allContestants.Add(new Winner(ContestantWinner));
            CurrentSweepstakes.PrintContestantInfo(ContestantWinner);  //this will be changed with observer pattern   
            
            foreach(IContestant entries in allContestants)
            {
                entries.PostWinner();
            }
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