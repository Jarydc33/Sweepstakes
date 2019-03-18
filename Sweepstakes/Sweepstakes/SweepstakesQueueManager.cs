using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        Queue<Sweepstakes> QueueManager;

        public SweepstakesQueueManager()
        {
            QueueManager = new Queue<Sweepstakes>();
        }

        public Sweepstakes GetSweepstakes()
        {
            return QueueManager.Dequeue();   
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            QueueManager.Enqueue(sweepstakes);
        }

    }
}