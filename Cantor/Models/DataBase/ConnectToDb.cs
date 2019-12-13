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

        public void userUpdateSell(string email, float profit, string howMuch, string currency)
        {
            string query = "UPDATE `users` SET `PLN`=`PLN`+" + (int)profit + ",`" + currency + "`=`" + currency + "`-" + howMuch + " WHERE `email` = '" + email + "';";
            ConnectToDb go = new ConnectToDb();
            go.connectToDb();

            MySqlCommand cmd1 = new MySqlCommand(query, connector);
            connector.Open();
            cmd1.ExecuteNonQuery();
            go.closeConnectToDb();
            connector.Close();

            string query1 = "UPDATE `cantorstock` SET `" + currency + "`=`" + currency + "`+" + howMuch + " where `id` = 1;";
            ConnectToDb go1 = new ConnectToDb();
            go1.connectToDb();

            MySqlCommand cmd = new MySqlCommand(query1, connector);
            connector.Open();
            cmd.ExecuteNonQuery();
            go1.closeConnectToDb();
        }

        public void userUpdateBuy(string email, float price, string howMuch, string currency)
        {
            string query = "UPDATE `users` SET `PLN`=`PLN`-" + (int)price + ",`"+currency+"`=`"+currency+"`+"+howMuch+" WHERE `email` = '"+email+"';";
            ConnectToDb go = new ConnectToDb();
            go.connectToDb();

            MySqlCommand cmd1 = new MySqlCommand(query, connector);
            connector.Open();
            cmd1.ExecuteNonQuery();
            go.closeConnectToDb();
            connector.Close();
                            
            string query1 = "UPDATE `cantorstock` SET `"+currency+"`=`"+currency+"`-"+howMuch+" where `id` = 1;";
            ConnectToDb go1 = new ConnectToDb();
            go1.connectToDb();

            MySqlCommand cmd = new MySqlCommand(query1, connector);
            connector.Open();
            cmd.ExecuteNonQuery();
            go1.closeConnectToDb();
        }

        public string selectCantorStock(string currency)
        {
            string query = "SELECT `"+currency+"` FROM `cantorstock` where id = 1 ; ";
            MySqlCommand command = new MySqlCommand(query, connector);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                return reader[currency]+"";
            }
            return "0";
            
        }

        public Array selectLast()
        {
            string query = "SELECT * FROM `cantorcurrencies` order by id DESC limit 1; ";

            MySqlCommand command = new MySqlCommand(query, connector);
            MySqlDataReader reader = command.ExecuteReader();
            String val = "";
            String[] x = new String[13];
            while (reader.Read())
            {

                x[0] = reader["date"]+"";
                x[1] = reader["USD_PURCASE"] + "";
                x[2] = reader["USD_SELL"] + "";
                x[3] = reader["EUR_PURCASE"] + "";
                x[4] = reader["EUR_SELL"] + "";
                x[5] = reader["CHF_PURCASE"] + "";
                x[6] = reader["CHF_SELL"] + "";
                x[7] = reader["RUB_PURCASE"] + "";
                x[8] = reader["RUB_SELL"] + "";
                x[9] = reader["CZK_PURCASE"] + "";
                x[10] = reader["CZK_SELL"] + "";
                x[11] = reader["GBP_PURCASE"] + "";
                x[12] = reader["GBP_SELL"] + "";
                
            }
            reader.Close();

            return x;
        }

        public void addcurriences(String query)
        {
            String insert = "INSERT INTO cantorcurrencies(date, USD_PURCASE, USD_SELL, EUR_PURCASE, EUR_SELL, CHF_PURCASE, CHF_SELL, RUB_PURCASE, RUB_SELL, CZK_PURCASE, CZK_SELL, GBP_PURCASE, GBP_SELL) VALUES(" + query + ")";

            ConnectToDb go = new ConnectToDb();
            go.connectToDb();

            MySqlCommand cmd = new MySqlCommand(insert, connector);
            cmd.ExecuteNonQuery();
            go.closeConnectToDb();
        }

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
                                `USD_PURCASE` text DEFAULT '',
                                `USD_SELL` text DEFAULT '',
                                `EUR_PURCASE` text DEFAULT '',
                                `EUR_SELL` text DEFAULT '',
                                `CHF_PURCASE` text DEFAULT '',
                                `CHF_SELL` text DEFAULT '',
                                `RUB_PURCASE` text DEFAULT '',
                                `RUB_SELL` text DEFAULT '',
                                `CZK_PURCASE` text DEFAULT '',
                                `CZK_SELL` text DEFAULT '',
                                `GBP_PURCASE` text DEFAULT '',
                                `GBP_SELL` text DEFAULT '',
                                PRIMARY KEY (`id`))
                                ENGINE = MyISAM AUTO_INCREMENT = 1 ;", "cantorcurrencies");

            string queryTable2 = string.Format(@"CREATE TABLE `{0}` (
                                `id` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
                                `USD` INT DEFAULT '20000',
                                `EUR` INT DEFAULT '20000',
                                `CHF` INT DEFAULT '20000',
                                `RUB` INT DEFAULT '20000',
                                `CZK` INT DEFAULT '20000',
                                `GBP` INT DEFAULT '20000',                     
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

                String insert = "INSERT INTO cantorstock(USD,EUR,CHF,RUB,CZK,GBP) VALUES('20000','20000','20000','20000','20000','20000')";         

                MySqlCommand cmd = new MySqlCommand(insert, connector);
                cmd.ExecuteNonQuery();
                go.closeConnectToDb();
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
