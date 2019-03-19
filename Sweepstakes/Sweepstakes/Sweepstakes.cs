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
        Dictionary<string, Contestant> sweepstakesDictionary;
        string name;
        public string Name { get => name; }
        int numberOfContestants;
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
            Random WinnerPicker = new Random();
            int winningRegistration;
            string stringWinner;
            winningRegistration = WinnerPicker.Next(0, numberOfContestants);
            stringWinner = winningRegistration.ToString();

            contestWinner = RemoveContestant(stringWinner);

            sweepstakesDictionary.Add(stringWinner, contestWinner);

            foreach(KeyValuePair<string,Contestant> contestants in sweepstakesDictionary)
            {
                PrintContestantInfo(contestants.Value);
            }
            return contestWinner.FirstName + contestWinner.LastName;
        }

        public Winner RemoveContestant(string winningReg)
        {
            foreach (KeyValuePair<string, Contestant> winningNumber in sweepstakesDictionary)
            {
                if (winningReg == winningNumber.Key)
                {
                    contestWinner = new Winner(winningNumber.Value.FirstName, winningNumber.Value.LastName, winningNumber.Value.Email, winningNumber.Key);
                    sweepstakesDictionary.Remove(winningNumber.Key);
                    break;

                }

            }
            return contestWinner;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine("{0} {1}, {2}", contestant.FirstName, contestant.LastName, contestant.Email);
            contestant.PostWinner();
            //SendEmail(contestant);
            
        }

        //public void SendEmail(Contestant contestant)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("Marketing Firm", "MarketFirmTester@outlook.com"));
        //    message.To.Add(new MailboxAddress(contestant.FirstName + contestant.LastName, contestant.Email));
        //    message.Subject = "Congratulations!";

        //    message.Body = new TextPart("plain")
        //    {
        //        Text = @"Congratulations "+ contestant.FirstName+", you entered our marketing sweepstakes and you won! We wanted to send a message out to congratulate you!"
        //    };

        //    using (var client = new MailKit.Net.Smtp.SmtpClient())
        //    {               
        //        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
        //        client.Connect("smtp.office365.com", 587, false);
        //        client.Authenticate("MarketFirmTester@outlook.com", "P@$$w0rd");
        //        client.Send(message);
        //        client.Disconnect(true);
        //    }
            
            
        //}
    }
    

}