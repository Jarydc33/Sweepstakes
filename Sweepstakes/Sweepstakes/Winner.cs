using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Winner : IContestant
    {
        Contestant winner;
        public Winner(Contestant winner)
        {
            this.winner = winner;
        }

        public void PostWinner()
        {
            
        }
    }
}
