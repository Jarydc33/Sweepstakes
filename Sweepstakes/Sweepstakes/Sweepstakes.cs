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
        public string Name { get => name; }
        int numberOfContestants;
        List<Contestant> contestants;

        public Sweepstakes(string name)
        {
            sweepstakesDictionary = new Dictionary<string, string>();
            this.name = name;
            numberOfContestants = 0;
        }

        public void RegisterContestant(Contestant contestant)
        {
            string fullName = contestant.FirstName + " " + contestant.LastName;
            contestants.Add(contestant);
            sweepstakesDictionary.Add(contestant.RegistrationNum, fullName);
            numberOfContestants++;
            
        }

        public string PickWinner()
        {
            Random WinnerPicker = new Random();
            int winningRegistration;
            string stringWinner;
            winningRegistration = WinnerPicker.Next(0, numberOfContestants);
            stringWinner = winningRegistration.ToString();

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