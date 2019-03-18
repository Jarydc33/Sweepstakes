using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        public Stack<Sweepstakes> StackManager;

        public SweepstakesStackManager()
        {
            StackManager = new Stack<Sweepstakes>();
        }

        public Sweepstakes GetSweepstakes()
        {
            return StackManager.Pop();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            StackManager.Push(sweepstakes);
        }

    }
}