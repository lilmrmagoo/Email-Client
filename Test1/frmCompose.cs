using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Test1
{
    public partial class frmCompose : Form
    {
        public EmailService EmailService { private get; set; }
        
        public frmCompose()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
                EmailDTO dto = parseInputs();
                if(dto!=null)EmailService.SendMessage(dto);
                this.Hide();
        }
        private EmailDTO parseInputs()
        {
            EmailDTO dto = new EmailDTO() { Body = txtEmailBody.Text, Subject = txtEmailSubject.Text };
            Regex email = new Regex(@"^[\w-\.]+@(?:[\w-]+\.)+[\w-]{2,5}$");
            if (!email.IsMatch(txtEmailTo.Text)) { MessageBox.Show("Invalid email address in destitnation field"); return null; }
            else
            {
                dto.To = txtEmailTo.Text;
                return dto;
            }
        }
    }
}
