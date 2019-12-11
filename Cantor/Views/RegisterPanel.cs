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
            if (status == true)
            {
                register.finishRegister();
                Close();
            }
            else
            {
                MessageBox.Show("Some value input to register is incorrect!.", "Problem in value", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }
    }
}
