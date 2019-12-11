using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cantor.Models
{
    class Head 
    {
       public Head() { }

        public ClientPanel CPanel { get; set; }
        public LoginPanel LPanel { get; set; }
        public RegisterPanel RPanel { get; set; }
       
        public void createPanel()
        {
            LPanel = new LoginPanel();
            RPanel = new RegisterPanel();
            LPanel.rPanel = RPanel;
            LPanel.lPanel = LPanel;

            Application.Run(LPanel);
        }

    }
}
