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
            string userInput = UI.ChooseInterface();
            SweepstakesStackManager _StackManager;
            SweepstakesQueueManager _QueueManager;
            MarketingFirm myFirm;
            switch (userInput.ToLower())
            {
                case "stack":
                    _StackManager = new SweepstakesStackManager();
                    myFirm = new MarketingFirm(_StackManager);
                    break;

                default:
                    _QueueManager = new SweepstakesQueueManager();
                    myFirm = new MarketingFirm(_QueueManager);
                    break;
            }
        }
    }
}
