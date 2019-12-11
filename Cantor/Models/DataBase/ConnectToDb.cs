using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Cantor.Models.DataBase
{
    class ConnectToDb
    {
        private string ipServer = "127.0.0.1";
        private string UID = "Admin";
        private string password = "qwertyuiop";
        private string database = "FutureProcessing";
        public MySqlConnection connector { get; set; }

        public ConnectToDb() { }

        public string select(string email)
        {
            string query = "SELECT * FROM Users where email ='"+email+"'";
            MySqlCommand command = new MySqlCommand(query, connector);
            MySqlDataReader reader = command.ExecuteReader();
            String val = "";

            while (reader.Read())
            {
                val = reader["email"].ToString(); ;                                      
            }

            reader.Close();
            return val;

        }
        public void connectToDb()
        {
            try
            {
                string connstring = string.Format("Server=" + ipServer + "; database={0}; UID=" + UID + "; password=" + password, database);
                MySqlConnection connect = new MySqlConnection(connstring);

                connector = connect;
                connect.Open();
                Console.WriteLine("you are connected!");

            }catch(Exception err)
            {
                Console.WriteLine(err);
            }
        }

        public void addUser(string data)
        {
            String insert = "INSERT INTO Users(firstName, lastName, nick, email, password,USD,EUR,CHF,RUB,CZK,GBP,PLN) VALUES("+data+")";

            ConnectToDb go = new ConnectToDb();
            go.connectToDb();

            MySqlCommand cmd = new MySqlCommand(insert, connector);
            cmd.ExecuteNonQuery();
            go.closeConnectToDb();
        }

        public void checkTable()
        {
            string quetyTable = string.Format(@"CREATE TABLE `{0}` (
                                `id` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
                                `firstName` text  DEFAULT '',
                                `lastName` text  DEFAULT '',
                                `nick` text NOT NULL,
                                `email` text ,
                                `password` text NOT NULL,
                                `USD` text NOT NULL DEFAULT '',
                                `EUR` text NOT NULL DEFAULT '',
                                `CHF` text NOT NULL,
                                `RUB` text NOT NULL,
                                `CZK` text NOT NULL,
                                `GBP` text NOT NULL,
                                `PLN` text NOT NULL,                              
                                PRIMARY KEY (`id`))
                                ENGINE = MyISAM AUTO_INCREMENT = 1 ;", "USers");

            ConnectToDb go = new ConnectToDb();
            go.connectToDb();
            MySqlCommand createTable = new MySqlCommand(quetyTable, connector);
            try
            {
                createTable.ExecuteNonQuery();
            }catch(MySqlException err)
            {
                Console.WriteLine("this table exist");
            }
            go.closeConnectToDb();
        }

        public void closeConnectToDb()
        {
            try
            {
                this.connector.Close();
                Console.WriteLine("Your connect is closed.!");
            }catch(Exception err)
            {
                Console.WriteLine(err);
            }
        }

    }
}
