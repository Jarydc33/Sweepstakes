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

            MarketingFirm MyFirm = new MarketingFirm(_Manager);

            MyFirm.InsertNewSweepstakes(new Sweepstakes("Free car!"));
            MyFirm.GetNewSweepstakes();

            MyFirm.GetEntries();
            MyFirm.GetEntries();

            MyFirm.PickWinner();
        }
    }
}
