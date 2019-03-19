using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerChooser myManager = new ManagerChooser();
            string choice = UI.ChooseInterface();
            ISweepstakesManager _Manager = myManager.UserChoice(choice);

            _Manager.InsertSweepstakes(new Sweepstakes("New car giveaway!"));
            _Manager.InsertSweepstakes(new Sweepstakes("New boat giveaway!"));
            _Manager.InsertSweepstakes(new Sweepstakes("Vacation giveaway!"));
            _Manager.InsertSweepstakes(new Sweepstakes("Luxury cruise giveaway!"));
            _Manager.InsertSweepstakes(new Sweepstakes("Dog giveaway!"));

            MarketingFirm MyFirm = new MarketingFirm(_Manager);
        }
    }
}
