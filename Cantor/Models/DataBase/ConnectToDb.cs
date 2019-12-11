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

        public Array catchAllInformation(string email)
        {
            string query = "SELECT * FROM Users where email ='" + email + "'";

            MySqlCommand command = new MySqlCommand(query, connector);
            MySqlDataReader reader = command.ExecuteReader();
            String val = "";
            String[] x = new String[11];
            while (reader.Read())
            {
                x[0] = reader["firstName"].ToString();
                x[1] = reader["lastName"].ToString();
                x[2] = reader["nick"].ToString();
                x[3] = reader["email"].ToString();
                x[4] = reader["USD"].ToString();
                x[5] = reader["EUR"].ToString();
                x[6] = reader["CHF"].ToString();
                x[7] = reader["RUB"].ToString();
                x[8] = reader["CZK"].ToString();
                x[9] = reader["GBP"].ToString();
                x[10] = reader["PLN"].ToString();
            }
            reader.Close();

            Console.WriteLine(x[0] +" "+ x[1]);

            return x;
        }


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

        public Boolean logIn(string email, string password)
        {


            string query = "SELECT * FROM Users where email ='" + email + "' and password = '"+password+"'";

            MySqlCommand command = new MySqlCommand(query, connector);
            MySqlDataReader reader = command.ExecuteReader();
            String val = "";

            while (reader.Read())
            {
                val = reader["email"].ToString() + "-" + reader["password"].ToString(); 
            }
            reader.Close();
            Console.WriteLine(val +" wartosc z bazy");

            if(val == (email + "-" + password))
            {
                return true;
            }
            else
            {
                return false;
            }         
        }

        public void connectToDb()
        {
            try
            {
                string connstring = string.Format("Server=" + ipServer + "; database={0}; UID=" + UID + "; password=" + password, database);
                MySqlConnection connect = new MySqlConnection(connstring);

                connector = connect;
                connect.Open();

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
            string queryTable = string.Format(@"CREATE TABLE `{0}` (
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
                                ENGINE = MyISAM AUTO_INCREMENT = 1 ;", "Users");

            string queryTable1 = string.Format(@"CREATE TABLE `{0}` (
                                `id` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
                                `date` text DEFAULT '',
                                `USD_PURCASE` INT DEFAULT 0,
                                `USD_SELL` INT DEFAULT 0,
                                `EUR_PURCASE` INT DEFAULT 0,
                                `EUR_SELL` INT DEFAULT 0,
                                `CHF_PURCASE` INT DEFAULT 0,
                                `CHF_SELL` INT DEFAULT 0,
                                `RUB_PURCASE` INT DEFAULT 0,
                                `RUB_SELL` INT DEFAULT 0,
                                `CZK_PURCASE` INT DEFAULT 0,
                                `CZK_SELL` INT DEFAULT 0,
                                `GBP_PURCASE` INT DEFAULT 0,
                                `GBP_SELL` INT DEFAULT 0,
                                PRIMARY KEY (`id`))
                                ENGINE = MyISAM AUTO_INCREMENT = 1 ;", "cantorcurrencies");

            string queryTable2 = string.Format(@"CREATE TABLE `{0}` (
                                `id` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
                                `USD` INT  DEFAULT 0,
                                `EUR` INT  DEFAULT 0,
                                `CHF` INT  DEFAULT 0,
                                `RUB` INT  DEFAULT 0,
                                `CZK` INT  DEFAULT 0,
                                `GBP` INT  DEFAULT 0,                     
                                PRIMARY KEY (`id`))
                                ENGINE = MyISAM AUTO_INCREMENT = 1 ;", "cantorstock");

            ConnectToDb go = new ConnectToDb();
            go.connectToDb();
            MySqlCommand createTable = new MySqlCommand(queryTable, connector);
            try
            {
                createTable.ExecuteNonQuery();
            }catch(MySqlException err)
            {
                Console.WriteLine("this table exist");
            }

            MySqlCommand createTable1 = new MySqlCommand(queryTable1, connector);
            try
            {
                createTable1.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine("this table exist");
            }

            MySqlCommand createTable2 = new MySqlCommand(queryTable2, connector);
            try
            {
                createTable2.ExecuteNonQuery();
            }
            catch (MySqlException err)
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
