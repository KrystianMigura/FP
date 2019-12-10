using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor.Models
{
    class RegisterNewUser
    {
       public RegisterNewUser() { }

       public Boolean catchValue(String fName, String sName, String nick, String email, String password, String USD, String EUR, String CHF, String RUB, String CZK, String GBP, String PLN)
        {
            Models.Validations.Validator valid = new Models.Validations.Validator();

            Boolean _fName = valid.checkLogin(fName);
            Boolean _sName = valid.checkLogin(sName);
            Boolean _nick = valid.checkLogin(nick);

            Boolean _email = valid.email(email);

            
            Boolean _USD = valid.currency(USD);
            Boolean _EUR = valid.currency(EUR);
            Boolean _CHF = valid.currency(CHF);
            Boolean _RUB = valid.currency(RUB);
            Boolean _CZK = valid.currency(CZK);
            Boolean _GBP = valid.currency(GBP);
            Boolean _PLN = valid.currency(PLN);

            if (_fName && _sName == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


        
    }
}
