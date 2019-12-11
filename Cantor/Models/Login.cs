using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantor.Models
{
    class Login
    {
        DataBase.ConnectToDb connector { get; set; }
        public Login() { }

        public void mysqlConnector()
        {
            Models.DataBase.ConnectToDb connect = new DataBase.ConnectToDb();           
            this.connector = connect;
        }

        public void openConnection()
        {
            this.connector.connectToDb();
        }

        public void closeConnection()
        {
            this.connector.closeConnectToDb();
        }

        public void checTable()
        {
            this.connector.checkTable();
        }
    }
}
