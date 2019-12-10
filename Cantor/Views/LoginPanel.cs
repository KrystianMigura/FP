using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cantor
{
    public partial class LoginPanel : Form
    {
        private Models.Login DB { get; set; }
        public RegisterPanel rPanel { get; set; }
        public LoginPanel lPanel { get; set; }
        public LoginPanel()
        {
            InitializeComponent();
            Models.Login optionsForLogin = new Models.Login();
            DB = optionsForLogin;
            DB.mysqlConnector();

            DB.openConnection();

            DB.closeConnection();
        }

        private void registerButton(object sender, EventArgs e)
        {

            Models.logButton.Buttons register = new Models.logButton.Buttons();
            register.registerButton();

        }

        private void loginButton(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            String password = textBox2.Text;
            Models.logButton.Buttons register = new Models.logButton.Buttons();
            register.loginButton(DB, login, password);
        }
    }
}
