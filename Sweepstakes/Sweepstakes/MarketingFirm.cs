using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sweepstakes
{
    public class MarketingFirm
    {
        Sweepstakes CurrentSweepstakes;
        ISweepstakesManager _manager;
        int registrationCounter;

        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;
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
            Contestant tempContestant = new Contestant(newEntry[0], newEntry[1], newEntry[2], registrationNumber);
            CurrentSweepstakes.RegisterContestant(tempContestant);
            registrationCounter++;
        }

        public void DetermineWinner()
        {
            string winner = CurrentSweepstakes.PickWinner(); //name of winner
            
        }

        public string CreateRegistrationNumber()
        {
            int registration = registrationCounter;
            string stringRegistration = registration.ToString();
            return stringRegistration;
        }

        
    }
}