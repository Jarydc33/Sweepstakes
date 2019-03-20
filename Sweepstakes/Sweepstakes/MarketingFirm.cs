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
    public class MarketingFirm
    {
        Sweepstakes CurrentSweepstakes;
        ISweepstakesManager _manager;
        string winner;

        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;

        }

        public void InsertNewSweepstakes(Sweepstakes sweepstakesToInsert)
        {
            _manager.InsertSweepstakes(sweepstakesToInsert);
        }

        public void GetNewSweepstakes()
        {
            CurrentSweepstakes = _manager.GetSweepstakes();
        }

        public void GetEntries()
        {
            string[] newEntry = new string[3];
            newEntry[0] = UI.EnterInfo("First Name");
            newEntry[1] = UI.EnterInfo("Last Name");
            newEntry[2] = UI.EnterInfo("Email");
            string newRegistration = CurrentSweepstakes.numberOfContestants.ToString();
            CurrentSweepstakes.RegisterContestant(new Contestant(newEntry[0], newEntry[1], newEntry[2], newRegistration));
        }

        public void DetermineWinner()
        {
            winner = CurrentSweepstakes.PickWinner();
            //SendEmail(CurrentSweepstakes.contestWinner);

        }

        public void SendEmail(Contestant contestant)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Marketing Firm", "marketfirmnotifier@outlook.com"));
            message.To.Add(new MailboxAddress(contestant.FirstName + contestant.LastName, contestant.Email));
            message.Subject = "Congratulations!";

            message.Body = new TextPart("plain")
            {
                Text = @"Congratulations " + contestant.FirstName + ", you entered our marketing sweepstakes and you won! We wanted to send a message out to congratulate you!"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587);
                client.Authenticate("marketfirmnotifier@outlook.com", "P@$$w0rd!!");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}