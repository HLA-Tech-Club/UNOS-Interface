using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace UNOSInterface
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private string accessToken;
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            lblLoginStatus.Text = "Authenticating...";
            var jsonResponse = API.RequestAuthToken(txtUser.Text, txtPassword.Text, "password");
            string accessGranted = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse)["access_token"].ToString();
            if (!String.IsNullOrEmpty(accessGranted))
            {
                accessToken = accessGranted;
                Hide();
                frmMain main = new frmMain();
                main.Show();
            }
            else
            {
                lblLoginStatus.Text = "Invalid credentials";
            }
        }
    }
}
