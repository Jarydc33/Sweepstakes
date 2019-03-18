using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        Dictionary<string, string> sweepstakesDictionary;
        string name;
        string Name { get => name; }
        int numberOfContestants;

        public Sweepstakes(string name)
        {
            sweepstakesDictionary = new Dictionary<string, string>();
            this.name = name;
            numberOfContestants = 0;
        }

        public void RegisterContestant(Contestant contestant)
        {
            string fullName = contestant.FirstName + " " + contestant.LastName;
            sweepstakesDictionary.Add(contestant.RegistrationNum, fullName);
            numberOfContestants++;
            
        }

        public string PickWinner()
        {
            Random WinnerPicker = new Random();
            int winner;
            string stringWinner;
            winner = WinnerPicker.Next(0, numberOfContestants);
            stringWinner = winner.ToString();

            foreach(KeyValuePair<string,string> winningNumber in sweepstakesDictionary)
            {
                if(stringWinner == winningNumber.Key)
                {
                    stringWinner = winningNumber.Value;
                }
            }

            return stringWinner;

        }

        public void PrintContestantInfo()
        {
            
        }
    }
}