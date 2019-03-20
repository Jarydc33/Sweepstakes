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

        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;
            
        }

        public void InsertNewSweepstakes(Sweepstakes sweepstakesToInsert)
        {
            _manager.InsertSweepstakes(sweepstakesToInsert);
        }

        public void GetNewSweepstakes()
        {
            try
            {
                CurrentSweepstakes = _manager.GetSweepstakes();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e);
            }   
            
        }

        public void GetEntries()
        {
            string[] newEntry = new string[3];
            newEntry = UI.EnterInfo();
            string newRegistration = CurrentSweepstakes.numberOfContestants.ToString();
            Contestant tempContestant = new Contestant(newEntry[0], newEntry[1], newEntry[2], newRegistration);
            CurrentSweepstakes.RegisterContestant(tempContestant);
        }

        public void DetermineWinner()
        {
            string winner = CurrentSweepstakes.PickWinner(); 
            
        }

        
    }
}