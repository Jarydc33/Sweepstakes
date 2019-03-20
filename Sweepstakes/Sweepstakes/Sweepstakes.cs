using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        Dictionary<string, Contestant> sweepstakesDictionary;
        string name;
        public string Name { get => name; }
        public int numberOfContestants;
        public Winner contestWinner;

        public Sweepstakes(string name)
        {
            sweepstakesDictionary = new Dictionary<string, Contestant>();
            this.name = name;
            numberOfContestants = 0;
        }

        public void RegisterContestant(Contestant contestant)
        {
            sweepstakesDictionary.Add(contestant.RegistrationNum,contestant);
            numberOfContestants++;
            
        }

        public string PickWinner()
        {
            Random winnerPicker = new Random();
            int winningRegistration;
            string stringWinner;
            winningRegistration = winnerPicker.Next(0, numberOfContestants);
            stringWinner = winningRegistration.ToString();

            contestWinner = RemoveContestant(stringWinner);

            sweepstakesDictionary.Add(stringWinner, contestWinner);

            NotifyAll();

            return contestWinner.FirstName + contestWinner.LastName; //why is this returning?
        }

        public void NotifyAll()
        {
            foreach (KeyValuePair<string, Contestant> contestants in sweepstakesDictionary)
            {
                PrintContestantInfo(contestants.Value);
                contestants.Value.Notify(contestWinner);
            }
        }

        public Winner RemoveContestant(string registrationToFind)
        {
            foreach (KeyValuePair<string, Contestant> registrations in sweepstakesDictionary)
            {
                if (registrationToFind == registrations.Key)
                {
                    contestWinner = new Winner(registrations.Value.FirstName, registrations.Value.LastName, registrations.Value.Email, registrations.Key);
                    sweepstakesDictionary.Remove(registrations.Key);
                    break;

                }

            }
            return contestWinner;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine("{0} {1}, {2}", contestant.FirstName, contestant.LastName, contestant.Email);
        }
    }
    

}