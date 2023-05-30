using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using System.Diagnostics;
using MailKit.Net.Imap;
using MailKit.Search;
using Org.BouncyCastle.Crypto;

namespace BL
{
    public class EmailService
    {
        private string _password;
        private string _email;
        private string _imapHost = "outlook.office365.com";
        private int _imapPort = 993;
        private string _smtpHost = "smtp.office365.com";
        private int _smtpPort = 587;

        public string ImapHost { private get => _imapHost; set => _imapHost = value; }
        public int ImapPort { private get => _imapPort; set => _imapPort = value; }
        public string SmtpHost { private get => _smtpHost; set => _smtpHost = value; }
        public int SmtpPort { private get => _smtpPort; set => _smtpPort = value; }
        public string Password { private get => _password; set => _password = value; }
        public string Email { private get => _email; set => _email = value; }

        public EmailService(string email, string password)
        {
            _password = password;
            _email = email;
        }

        public EmailService(string imapHost, int imapPort, string stmpHost, int stmpPort)
        {
            ImapHost = imapHost;
            ImapPort = imapPort;
            SmtpHost = stmpHost;
            SmtpPort = stmpPort;
        }

        private ImapClient ImapConnection()
        {
            ImapClient imap = new ImapClient();
            imap.CheckCertificateRevocation = false;
            imap.Connect(_imapHost, _imapPort, SecureSocketOptions.Auto);
            imap.Authenticate(_email, _password);
            return imap;
        }
        private SmtpClient SmtpConnection()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;
            smtp.Connect(_smtpHost, _smtpPort, SecureSocketOptions.Auto);
            smtp.Authenticate(_email, _password);
            return smtp;
        }

        public void SendMessage(EmailDTO data)
        {
            MimeMessage msg = new MimeMessage();
            msg.From.Add(MailboxAddress.Parse(_email));
            msg.To.Add(MailboxAddress.Parse(data.To));
            msg.Subject = data.Subject;
            msg.Body = new TextPart(TextFormat.Plain) { Text = data.Body };

            //SmtpClient client = new SmtpClient();
            //client.CheckCertificateRevocation = false;
            using (var client = SmtpConnection())
            {
                    client.Send(msg);
                    client.Disconnect(true);
                    client.Dispose();   
            }
        }
        public List<IMessageSummary> GetInbox()
        {
            List<IMessageSummary> inbox = new List<IMessageSummary>();
            using (var client = ImapConnection())
            {
                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(SearchQuery.All);
                var summaries = client.Inbox.Fetch(uids,MessageSummaryItems.UniqueId | MessageSummaryItems.Envelope);
                foreach (var summary in summaries) inbox.Add(summary);
                client.Disconnect(true);
                client.Dispose();
            }
            return inbox;
        }
        public bool testAuthentication() 
        {
            ImapClient imap = new ImapClient();
            SmtpClient smtp = new SmtpClient();
            try
            {
                imap.CheckCertificateRevocation = false;
                imap.Connect(_imapHost, _imapPort, SecureSocketOptions.Auto);
                imap.Authenticate(_email, _password);
                smtp.CheckCertificateRevocation = false;
                smtp.Connect(_smtpHost, _smtpPort, SecureSocketOptions.Auto);
                smtp.Authenticate(_email, _password);
                return true;
            }
            catch (AuthenticationException ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                imap.Disconnect(true);
                smtp.Disconnect(true);
                imap.Dispose();
                smtp.Dispose();
            }
        }
        public MimeMessage GetMessage(UniqueId uid) {
            using (var client = ImapConnection())
            {
                client.Inbox.Open(FolderAccess.ReadOnly);
                MimeMessage message = client.Inbox.GetMessage(uid);
                client.Disconnect(true);
                return message;
            }
        }
    }
}
