using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cantor
{
    public partial class ClientPanel : Form
    {
        public String loggedData { get; set; }
        
        private String firstName { get; set; }
        private String lastName { get; set; }
        private String nick { get; set; }

        private String email { get; set; }

        private String USD { get; set; }

        private String EUR { get; set; }

        private String CHF { get; set; }

        private String RUB { get; set; }

        private String CZK { get; set; }

        private String GBP { get; set; }

        private String PLN { get; set; }

        private string log1 { get; set; }

        private void loop(string log)
        {
            Controllers.CatchData cd = new Controllers.CatchData();
            CheckForIllegalCrossThreadCalls = false;

            new Thread(() => { 
                Thread.Sleep(20*1000); 
                cd.tryCatchData();

                actualization();
                userUpdate(log);
                loop(log); 
            
            
            }).Start();
        }

        private void userUpdate(string log)
        {
            log1 = log;
            Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
            DB.connectToDb();

            Array info = DB.catchAllInformation(log);
            String[] infoString = new String[11];
            Int16 i = 1;
            foreach (string x in info)
            {

                if (i == 1)
                {
                    firstName = x;
                }

                if (i == 2)
                {
                    lastName = x;
                }

                if (i == 3)
                {
                    nick = x;
                }

                if (i == 4)
                {
                    email = x;
                }

                if (i == 5)
                {
                    USD = x;
                }

                if (i == 6)
                {
                    EUR = x;
                }

                if (i == 7)
                {
                    CHF = x;
                }

                if (i == 8)
                {
                    RUB = x;
                }

                if (i == 9)
                {
                    CZK = x;
                }

                if (i == 10)
                {
                    GBP = x;
                }

                if (i == 11)
                {
                    PLN = x;
                }
                i++;

            }

            DB.closeConnectToDb();

            label46.Text = GBP;
            label47.Text = EUR;
            label48.Text = USD;
            label49.Text = CZK;
            label50.Text = CHF;
            label51.Text = RUB;
            label6.Text = PLN;
            label2.Text = "Logged in as " + firstName + " " + lastName;


            label52.Text = multiplication(label40.Text, GBP,1);
            label53.Text = multiplication(label41.Text, EUR,1);
            label54.Text = multiplication(label42.Text, USD,1);
            label55.Text = multiplication(label43.Text, CZK,100);
            label56.Text = multiplication(label44.Text, CHF,10);
            label57.Text = multiplication(label45.Text, RUB,100);
        }


        private void actualization()
        {
            Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
            DB.connectToDb();
            Array actualization = DB.selectLast();
            String[] actString = new String[13];
            int j = 0;
            foreach (string z in actualization)
            {
                if(j == 0)
                {
                    label58.Text = "rate by hour: " + z;
                }

                if(j == 1)
                {
                    label40.Text = z;
                }
                if (j == 2)
                {
                    label34.Text = z;
                }
                if (j == 3)
                {
                    label41.Text = z;
                }
                if (j == 4)
                {
                    label35.Text = z;
                }
                if (j == 5)
                {
                    label42.Text = z;
                }
                if (j == 6)
                {
                    label36.Text = z;
                }
                if (j == 7)
                {
                    label43.Text = z;
                }
                if (j == 8)
                {
                    label37.Text = z;
                }
                if (j == 9)
                {
                    label44.Text = z;
                }
                if (j == 10)
                {
                    label38.Text = z;
                }
                if (j == 11)
                {
                    label45.Text = z;
                }
                if (j == 12)
                {
                    label39.Text = z;
                }
                j++;
            }
            DB.closeConnectToDb();
        }

        public ClientPanel(string log)
        {
            loop(log);
   
            InitializeComponent();
            Models.ClntPanel.Controls fullControl = new Models.ClntPanel.Controls();
            userUpdate(log);
            actualization();
            userUpdate(log);

        }

        private string multiplication(String a, String b, int i)
        {
            float nm1;
            float nm2;
            float.TryParse(a, out nm1);
            float.TryParse(b, out nm2);
                    
            if(i == 10)
            {
                nm2 = nm2 / 10;
            }

            if(i == 100)
            {
                nm2 = nm2 / 100;
            }

            float z = nm1 * nm2;

            string resolve = z.ToString();

            return resolve;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult = MessageBox.Show("You want close application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(dialogResult == DialogResult.Yes) 
            {
                Application.Exit();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.BuySell buy = new Models.BuySell();
            string currency = label11.Text;
            string unit = label23.Text;
            string value = label34.Text;
            string howMuch = textBox1.Text;
            string money = label6.Text;
            buy.buy(email, currency, unit, value, howMuch, money);
            actualization();
            userUpdate(log1);
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Models.BuySell buy = new Models.BuySell();
            string currency = label12.Text;
            string unit = label24.Text;
            string value = label35.Text;
            string howMuch = textBox2.Text;
            string money = label6.Text;
            buy.buy(email, currency, unit, value, howMuch, money);
            actualization();
            userUpdate(log1);
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Models.BuySell buy = new Models.BuySell();
            string currency = label13.Text;
            string unit = label25.Text;
            string value = label36.Text;
            string howMuch = textBox3.Text;
            string money = label6.Text;
            buy.buy(email, currency, unit, value, howMuch, money);
            actualization();
            userUpdate(log1);
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Models.BuySell buy = new Models.BuySell();
            string currency = label14.Text;
            string unit = label26.Text;
            string value = label37.Text;
            string howMuch = textBox4.Text;
            string money = label6.Text;
            buy.buy(email, currency, unit, value, howMuch, money);
            actualization();
            userUpdate(log1);
            textBox4.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Models.BuySell buy = new Models.BuySell();
            string currency = label15.Text;
            string unit = label27.Text;
            string value = label38.Text;
            string howMuch = textBox5.Text;
            string money = label6.Text;
            buy.buy(email, currency, unit, value, howMuch, money);
            actualization();
            userUpdate(log1);
            textBox5.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Models.BuySell buy = new Models.BuySell();
            string currency = label16.Text;
            string unit = label28.Text;
            string value = label39.Text;
            string howMuch = textBox6.Text;
            string money = label6.Text;
            buy.buy(email, currency, unit, value, howMuch, money);
            actualization();
            userUpdate(log1);
            textBox6.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string currency = label17.Text;
            string unitPrice = label40.Text;
            string amount = label46.Text;
            string quantity = textBox7.Text;
            string money = label6.Text;

            Models.BuySell sell = new Models.BuySell();
            sell.sell(currency, unitPrice, amount, quantity, email, money);

            actualization();
            userUpdate(log1);
            textBox7.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string currency = label18.Text;
            string unitPrice = label41.Text;
            string amount = label47.Text;
            string quantity = textBox8.Text;
            string money = label6.Text;

            Models.BuySell sell = new Models.BuySell();
            sell.sell(currency, unitPrice, amount, quantity, email, money);

            actualization();
            userUpdate(log1);
            textBox8.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string currency = label19.Text;
            string unitPrice = label42.Text;
            string amount = label48.Text;
            string quantity = textBox9.Text;
            string money = label6.Text;

            Models.BuySell sell = new Models.BuySell();
            sell.sell(currency, unitPrice, amount, quantity, email, money);

            actualization();
            userUpdate(log1);
            textBox9.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string currency = label20.Text;
            string unitPrice = label43.Text;
            string amount = label49.Text;
            string quantity = textBox10.Text;
            string money = label6.Text;

            Models.BuySell sell = new Models.BuySell();
            sell.sell(currency, unitPrice, amount, quantity, email, money);

            actualization();
            userUpdate(log1);
            textBox10.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string currency = label21.Text;
            string unitPrice = label44.Text;
            string amount = label50.Text;
            string quantity = textBox11.Text;
            string money = label6.Text;

            Models.BuySell sell = new Models.BuySell();
            sell.sell(currency, unitPrice, amount, quantity, email, money);

            actualization();
            userUpdate(log1);
            textBox11.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string currency = label22.Text;
            string unitPrice = label45.Text;
            string amount = label51.Text;
            string quantity = textBox12.Text;
            string money = label6.Text;

            Models.BuySell sell = new Models.BuySell();
            sell.sell(currency, unitPrice, amount, quantity, email, money);

            actualization();
            userUpdate(log1);
            textBox12.Text = "";
        }
    }
}
