﻿using System;
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
    public partial class frmLogin : Form
    {
        private EmailService customservice = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EmailService service = customservice??(EmailService)cboHostSelect.SelectedValue;
            service.Password = txtPassword.Text;
            service.Email = txtEmail.Text;
            if (service.testAuthentication())
            {
                frmInbox frm = new frmInbox(service);
                frm.Show();
                this.Hide();
            }
            else MessageBox.Show("cannot login, authentication error");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Dictionary<string, EmailService> services = new Dictionary<string, EmailService>();
            services.Add("Outlook", new EmailService("outlook.office365.com", 993, "smtp.office365.com", 587));
            services.Add("Gmail", new EmailService("imap.gmail.com", 993, "smtp.gmail.com", 587));
            services.Add("Ethereal", new EmailService("imap.ethereal.email", 993, "smtp.ethereal.email", 587));
            cboHostSelect.DataSource = new BindingSource(services,null);
            cboHostSelect.DisplayMember = "Key";
            cboHostSelect.ValueMember = "Value";
        }

        private void btnCustomHost_Click(object sender, EventArgs e)
        {
            frmCustomService frmCustomService = new frmCustomService();
            DialogResult result = frmCustomService.ShowDialog();
            if(result == DialogResult.OK)
            {
                customservice = frmCustomService.service;
            }

        }
    }
}
