using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor.Models.Validations
{
    class Validator
    {
        public Validator() { }

        public Boolean currency(String check)
        {
            int size = check.Length;
            for(int i=0; i > size; i++)
            {
                if((Int16)check[i] < 0 && (Int16)check[i] > 9)
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean email(string check)
        {
            string[] stringValid = new string[] {"@"};

            Boolean test = check.Contains(stringValid[0]);
            Console.WriteLine("TESTAAAAAAAAAAAAAAAAAA: " + test);
            if(test == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkLogin(string check)
        {
            string[] stringValid =new string[] {"!","@","#","%","^","&","*","(",")","-","=","+","SELECT","INTO","ALIAS","select","into","alias"};

            for (int i = 0; i < stringValid.Length; i++)
            {
                Boolean test = check.Contains(stringValid[i]);
                if(test == true)
                {
                    return false;
                }
            }
            
            return true;
        }

        public Boolean checkPassword(string check)
        {

            
            return true;
        }

    }
}
