using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using MailKit.Net.Smtp;
using MailKit;

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
            contestants = new List<Contestant>();
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

        public void PrintContestantInfo(Contestant contestant)
        {
            UI.PrintWinner(Name, contestant.FirstName, contestant.LastName, contestant.Email);
            SendEmail(contestant);
            
        }

        public void SendEmail(Contestant contestant)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Marketing Firm", "MarketFirmTester@outlook.com"));
            message.To.Add(new MailboxAddress(contestant.FirstName + contestant.LastName, contestant.Email));
            message.Subject = "Congratulations!";

            message.Body = new TextPart("plain")
            {
                Text = @"Congratulations "+ contestant.FirstName+", you entered our marketing sweepstakes and you won! We wanted to send a message out to congratulate you!"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("157.56.252.134", 587, false);
                client.Authenticate("MarketFirmTester@outlook.com", "P@$$w0rd");
                client.Send(message);
                client.Disconnect(true);
            }
            
            
        }
    }
}