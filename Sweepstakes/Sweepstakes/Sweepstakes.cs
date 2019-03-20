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
        Winner contestWinner;

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
            
            //SendEmail(contestant);
            
        }

        //public void SendEmail(Contestant contestant)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("Marketing Firm", "MarketFirmTester@outlook.com"));
        //    message.To.Add(new MailboxAddress(contestant.FirstName + contestant.LastName, "jarydc333@gmail.com"));
        //    message.Subject = "Congratulations!";

        //    message.Body = new TextPart("plain")
        //    {
        //        Text = @"Congratulations " + contestant.FirstName + ", you entered our marketing sweepstakes and you won! We wanted to send a message out to congratulate you!"
        //    };

        //    using (var client = new SmtpClient())
        //    {
        //        client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
        //        client.Authenticate("MarketFirmNotifier@gmail.com", "P@$$w0rd!!");
        //        client.Send(message);
        //        client.Disconnect(true);
        //    }


        //}
    }
    

}