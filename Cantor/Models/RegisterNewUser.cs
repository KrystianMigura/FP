using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cantor.Models
{
   
    class RegisterNewUser
    {
        private String __fName { get; set; }
        private String __sName { get; set; }
        private String __nick { get; set; }
        private String __email { get; set; }
        private String __password { get; set; }
        private String __USD { get; set; }
        private String __EUR { get; set; }
        private String __CHF { get; set; }
        private String __RUB { get; set; }
        private String __CZK { get; set; }
        private String __GBP { get; set; }
        private String __PLN { get; set; }


        public RegisterNewUser() { }

       public Boolean catchValue(String fName, String sName, String nick, String email, String password, String USD, String EUR, String CHF, String RUB, String CZK, String GBP, String PLN)
        {
            __fName = fName;
            __sName = sName;
            __nick = nick;
            __email = email;
            __password = password;
            __USD = USD;
            __EUR = EUR;
            __CHF = CHF;
            __RUB = RUB;
            __CZK = CZK;
            __GBP = GBP;
            __PLN = PLN;
            Models.Validations.Validator valid = new Models.Validations.Validator();

            Boolean _fName = valid.checkLogin(__fName);
            Boolean _sName = valid.checkLogin(__sName);
            Boolean _nick = valid.checkLogin(__nick);

            Boolean _email = valid.email(__email);
          
            Boolean _USD = valid.currency(__USD);
            Boolean _EUR = valid.currency(__EUR);
            Boolean _CHF = valid.currency(__CHF);
            Boolean _RUB = valid.currency(__RUB);
            Boolean _CZK = valid.currency(__CZK);
            Boolean _GBP = valid.currency(__GBP);
            Boolean _PLN = valid.currency(__PLN);

            if (_fName == true && _sName == true && _email == true)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

        public void finishRegister()
        {
            if (__nick.Length > 0 && __password.Length > 0 && __email.Length > 0)
            {
                Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
                DB.connectToDb();
                String compareEmail = DB.select(__email);

                if (compareEmail == __email)
                {
                    MessageBox.Show("This email exist in DataBase! \n Please insert different email address.", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DB.checkTable();
                    CryptoMd5 crypto = new CryptoMd5();
                    String hashPassword = crypto.hash(__password);

                    String data = "'" + __fName + "','" + __fName + "','" + __nick + "','" + __email + "','" + hashPassword + "','" + __USD + "','" + __EUR + "','" + __CHF + "','" + __RUB + "','" + __CZK + "','" + __GBP + "','" + __PLN + "'";

                    DB.addUser(data);
                }
            }
        }
       
    }
}
