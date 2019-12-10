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
    public partial class RegisterPanel : Form
    {
        

        public RegisterPanel()
        {
            InitializeComponent();


      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String firstName = textBox1.Text;
            String lastName = textBox2.Text;
            String nick = textBox3.Text;
            String email = textBox4.Text;
            String password = textBox5.Text;
            String USD = textBox6.Text;
            String EUR = textBox7.Text;
            String CHF = textBox8.Text;
            String RUB = textBox9.Text;
            String CZK = textBox10.Text;
            String GBP = textBox11.Text;
            String PLN = textBox12.Text;

            Models.RegisterNewUser register = new Models.RegisterNewUser();
            Boolean status = register.catchValue(firstName, lastName, nick, email, password, USD, EUR, CHF, RUB, CZK, GBP, PLN);
            
            if(nick.Length > 0 && password.Length > 0)
            {
                Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
                DB.connectToDb();
                DB.checkTable();
                String data = "'"+firstName+"','"+ lastName + "','" + nick + "','" + email + "','" + password + "','" + USD + "','" + EUR + "','" + CHF + "','" + RUB + "','" + CZK + "','" + GBP + "','" + PLN+"'";

                DB.addUser(data, email);
            }
            else
            {
                Console.WriteLine("you dont write information abou tuser");
            }
            Console.WriteLine("OCZEKIWANA: " + status);
        }
    }
}
