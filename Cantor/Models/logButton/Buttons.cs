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

        public void loginButton(Login DB, string login, string password)
        {
            Models.Validations.Validator valid = new Validations.Validator();

            Boolean lValid = valid.checkLogin(login);

            Boolean pValid = valid.checkPassword(password);

            Console.WriteLine("login test: " + lValid);

            DB.openConnection();


            DB.closeConnection();
        }
    }
}
