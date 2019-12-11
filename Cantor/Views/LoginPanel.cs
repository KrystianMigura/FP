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
            DB.checTable();
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
            Models.logButton.Buttons loginToPanel = new Models.logButton.Buttons();
            Boolean status = loginToPanel.loginButton(login, password);
            if(status == true)
            {
                this.Hide();
                ClientPanel clntPanel = new ClientPanel(login);
                clntPanel.Show();
            }
            else
            {
                MessageBox.Show("Wrong email or password. \n If you don't have account please register.","Information about Login.",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
