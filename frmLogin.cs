using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace UNOSInterface
{
    public partial class frmLogin : Form
    {
        bool debugMode = true;

        public frmLogin()
        {
            InitializeComponent();
            if (debugMode)
            {
                txtUser.Text = "BetaDivyank";
                txtPassword.Text = "f&!6f3vG^!YeVF";
            }
        }

        private string accessToken;
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            lblLoginStatus.Text = "Authenticating...";
            string accessGranted =
                api.RequestAuthToken(txtUser.Text, txtPassword.Text, "password");
            if (!String.IsNullOrEmpty(accessGranted))
            {
                accessToken = accessGranted;
                UseWaitCursor = true;
                Hide();
                frmMain main = new frmMain();
                main.Show();
                UseWaitCursor = false;
            }
            else
            {
                lblLoginStatus.Text = "Invalid credentials";
            }
        }
    }
}
