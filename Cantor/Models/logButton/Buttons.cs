using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor.Models.logButton
{
    class Buttons 
    {
        public Buttons() { }

        public void registerButton()
        {
            RegisterPanel rPanel = new RegisterPanel();
            rPanel.Show();
        }

        public Boolean loginButton(string login, string password)
        {
            String hashPassword = "";
            CryptoMd5 hash = new CryptoMd5();
            Models.Validations.Validator valid = new Validations.Validator();
            
            
            hashPassword = hash.hash(password);
 
               
            Boolean lValid = valid.email(login);
            if(lValid == true)
            {

                DataBase.ConnectToDb DB = new DataBase.ConnectToDb();
                DB.connectToDb();
                Boolean resolve = DB.logIn(login, hashPassword);
                if(resolve == true)
                {
                    return true;
                }

            }
            return false;

            

        }
    }
}
