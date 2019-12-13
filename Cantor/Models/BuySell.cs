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

        public void sell(String currency, String unitPrice, String amount, String quentity, String email, String money)
        {
            int at = quentity.IndexOf(",");
            Models.Validations.Validator valid = new Validations.Validator();
            Boolean _quentity = valid.currency(quentity);

            float funitPrice;
            float famount;
            float fquentity;
            float fmoney;
            float.TryParse(unitPrice, out funitPrice);
            float.TryParse(amount, out famount);
            float.TryParse(quentity, out fquentity);
            float.TryParse(money, out fmoney);
            int howMuch;

            if(_quentity == false || fquentity <=0 || at != -1)
            {
                MessageBox.Show("Wrong value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if(_quentity != false && fquentity > 0 && at == -1)
            {
                float profit = fquentity * funitPrice;
                howMuch = (int)fquentity;

                if (currency == "CZK")//100
                {
                    howMuch = (int)fquentity ;
                    profit = profit / 100;
                }

                if (currency == "CHF") //10
                {

                    howMuch = (int)fquentity ;
                    profit = profit / 10;
                }

                if (currency == "RUB")//100
                {
                    howMuch = (int)fquentity ;
                    profit = profit / 100;
                }
            
            
                if(famount < howMuch)
                {
                    MessageBox.Show("You don't have that much resources", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                if (famount >= howMuch)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to make this transaction? \n Profit: " + profit, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
                        DB.connectToDb();
                        //update user 
                        DB.closeConnectToDb();
                        DB.userUpdateSell(email, profit, howMuch.ToString(), currency);


                    }
                }
            }
          
        }


        public void buy(String email, String currency, String unit, String value, String howMuch, String money)
        {
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
            int __howMuch;
            int.TryParse(howMuch, out __howMuch);


            if (_howMuch == false || nm2 <= 0 || at != -1)
            {
                MessageBox.Show("Wrong value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (_howMuch != false && nm2 > 0 && at == -1)
            {
                    
                float cost = nmunit * nm2 * nmvalue;

                if (currency == "CZK")//100
                {
                    cost = cost / 100;
                    __howMuch = __howMuch * 100;
                }

                if (currency == "CHF") //10
                {
                    cost = cost / 10;
                    __howMuch = __howMuch * 10;
                }

                if (currency == "RUB")//100
                {
                    cost = cost / 100;
                    __howMuch = __howMuch * 100;
                }


                if (cost > nmmoney)
                {
                    MessageBox.Show("You don't have that much money", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if(cost <= nmmoney)
                {
                    Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
                    DB.connectToDb();
                    String howMuchExist = DB.selectCantorStock(currency); // return value how much stay in cantor

             
                    int __howMuchExist;
                   
                    int.TryParse(howMuchExist, out __howMuchExist);

                    if (__howMuch <= __howMuchExist)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to make this transaction? \n Cost: " + cost , "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DB.closeConnectToDb();
                            DB.userUpdateBuy(email,cost,__howMuch.ToString(),currency);
                  
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cantor have only: " +__howMuchExist +" "+ currency, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
