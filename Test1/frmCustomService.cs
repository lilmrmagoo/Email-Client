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
    public partial class frmCustomService : Form
    {
        public EmailService service;
        public frmCustomService()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            service = new EmailService(txtIMAPHost.Text, Convert.ToInt32(txtIMAPPort.Text), txtSMTPHost.Text, Convert.ToInt32(txtSMTPPort.Text));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
