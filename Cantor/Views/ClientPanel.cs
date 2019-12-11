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

        public ClientPanel(string log)
        {
            loggedData = log;     
            InitializeComponent();
            Models.ClntPanel.Controls fullControl = new Models.ClntPanel.Controls();

            Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
            DB.connectToDb();

            Array info = DB.catchAllInformation(log);
            String[] infoString = new String[11];
            Int16 i = 1;
           foreach ( string x in info)
            {
                
                if (i == 1)
                {
                    firstName = x;
                }

                if(i == 2)
                {
                    lastName = x;
                }

                if( i == 3)
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
                    Console.WriteLine(USD + "USD?");
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
            Console.WriteLine(firstName + " " + lastName + " " + PLN + " TEST");

            
            DB.closeConnectToDb();

            label46.Text = GBP;
            label47.Text = EUR;
            label48.Text = USD;
            label49.Text = CZK;
            label50.Text = CHF;
            label51.Text = RUB;
            label6.Text = PLN;
            label2.Text = "Logged in as " +firstName+" "+lastName;


                     String X = label40.Text;
                     int nm;
            int.TryParse(X, out nm);

                         Console.WriteLine(nm + " TO " + nm * 100);
                   

            String lb40 = label40.Text;
            label52.Text = multiplication(lb40, GBP);
            label53.Text = multiplication(label41.Text, EUR);
            label54.Text = multiplication(label42.Text, USD);
            label55.Text = multiplication(label43.Text, CZK);
            label56.Text = multiplication(label44.Text, CHF);
            label57.Text = multiplication(label45.Text, RUB);


        }

        private string multiplication(String a, String b)
        {
            float nm1;
            float nm2;
            float.TryParse(a, out nm1);
            float.TryParse(b, out nm2);
                    
            float z = nm1 * nm2;
            string resolve = z.ToString();

            return resolve;

        }



     
    }
}
