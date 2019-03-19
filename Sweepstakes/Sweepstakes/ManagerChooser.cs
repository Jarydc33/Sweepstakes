using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class ManagerChooser
    {

        public ManagerChooser()
        {
            
        }

        public ISweepstakesManager UserChoice(string choice)
        {
            switch (choice)
            {
                case "stack":
                    SweepstakesStackManager _StackManager = new SweepstakesStackManager();
                    return _StackManager;

                case "queue":
                    SweepstakesQueueManager _QueueManager = new SweepstakesQueueManager();
                    return _QueueManager;

                default:
                    SweepstakesQueueManager _DefaultQueueManager = new SweepstakesQueueManager();
                    return _DefaultQueueManager;
            }
        }
    }
}
