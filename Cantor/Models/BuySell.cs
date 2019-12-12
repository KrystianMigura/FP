using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cantor.Models
{
    class BuySell
    {
        public BuySell( ) { }

        public void buy(String email, String currency, String unit, String value, String howMuch, String money)
        {
            Console.WriteLine(email + " " + currency + " " + unit + " " + value + " " + howMuch +"GOOOG");
            int at = howMuch.IndexOf(",");

            Models.Validations.Validator valid = new Validations.Validator();
            Boolean _howMuch = valid.currency(howMuch);

            float nm2;
            float nmunit;
            float nmvalue;
            float nmmoney;
            float.TryParse(howMuch, out nm2);
            float.TryParse(unit, out nmunit);
            float.TryParse(value, out nmvalue);
            float.TryParse(money, out nmmoney);

            if (_howMuch == false || nm2 <= 0 || at != -1)
            {
                MessageBox.Show("Wrong value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (_howMuch != false && nm2 > 0 && at == -1)
            {
                Console.WriteLine(nmunit + " " + nm2 + " " + nmvalue);
                    
                float cost = nmunit * nm2 * nmvalue;

                if(cost > nmmoney)
                {
                    MessageBox.Show("You don't have that much money", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if(cost <= nmmoney)
                {
                    Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
                    DB.connectToDb();
                    String howMuchExist = DB.selectCantorStock(currency); // return value how much stay in cantor

                    int __howMuch;
                    int __howMuchExist;
                    int.TryParse(howMuch, out __howMuch);
                    int.TryParse(howMuchExist, out __howMuchExist);

                    if (__howMuch <= __howMuchExist)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to make this transaction? \n Cost: " + cost , "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //update user 
                            DB.closeConnectToDb();
                            DB.userUpdateBuy(email,cost,howMuch,currency);
 
                  
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cantor have only: " +__howMuchExist +" "+ currency, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }



                }

                Console.WriteLine(cost);
            }

        }

    }
}
