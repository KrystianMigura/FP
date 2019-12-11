using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor.Models.ClntPanel
{
    class Controls 
    {
        string mainEmail { get; set; }
        public Controls() { }
    

        public void start(string email)
        {
            mainEmail = email;
        }
    }
}
