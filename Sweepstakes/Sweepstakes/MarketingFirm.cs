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
            catch(InvalidOperationException e) //need this?
            {
                Console.WriteLine(e);
            }   
            
        }

        public void GetEntries()
        {
            string[] newEntry = UI.EnterInfo();
            string newRegistration = CurrentSweepstakes.numberOfContestants.ToString();
            CurrentSweepstakes.RegisterContestant(new Contestant(newEntry[0], newEntry[1], newEntry[2], newRegistration));
        }

        public void DetermineWinner()
        {
            string winner = CurrentSweepstakes.PickWinner(); 
            
        }

        
    }
}