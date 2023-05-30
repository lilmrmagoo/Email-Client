using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Test1
{
    public partial class frmInbox : Form
    {
        private EmailService emailService;
        private List<MailKit.IMessageSummary> _inbox;
        public frmInbox()
        {
            InitializeComponent();
        }
        public frmInbox(EmailService service) {
            InitializeComponent();
            emailService = service;
        }
       

        private void btnCompose_Click(object sender, EventArgs e)
        {
            frmCompose frmCompose = new frmCompose();
            frmCompose.EmailService = emailService;
            frmCompose.Show();
        }

        private void frmInbox_Load(object sender, EventArgs e)
        {
            _inbox = emailService.GetInbox();
            var items = _inbox.Select(item => new
            {
                DisplayText = $"{item.Envelope.From}: \r\t {item.Envelope.Subject} \r\t {item.Envelope.Date}",
                Value = item
            });
            lstInbox.DisplayMember = "DisplayText";
            lstInbox.ValueMember = "Value";
            lstInbox.DataSource = items.ToList();
            
        }

        private void lstInbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getting the selected message summary, then the full message corresponding to its id.
            MimeKit.MimeMessage message = emailService.GetMessage(((MailKit.IMessageSummary)lstInbox.SelectedValue).UniqueId);
            string formated = $"From: {message.From}\r\nTo: {message.To}\r\nSubject: {message.Subject}\r\n\n {message.TextBody}";
            txtViewEmail.Text = formated;
        }
    }
}
