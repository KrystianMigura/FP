using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace Cantor.Controllers 
{
    class CatchData 
    {
       public CatchData() { }

        public void tryCatchData()
        {
            String xml = DownloadString(@"http://webtask.future-processing.com:8068/currencies");
            var obj = JObject.Parse(xml);
 
            String insert = "";

            for (int i = 0; i< 6; i++)
            {
                insert += "'"+ obj["items"][i]["purchasePrice"] + "','"+ obj["items"][i]["sellPrice"]+"',";
            }

            String correctInsert = "'" + obj["publicationDate"] + "'," + insert;

            int size = correctInsert.Length-1;
            correctInsert = correctInsert.Remove(size,1);

            Models.DataBase.ConnectToDb DB = new Models.DataBase.ConnectToDb();
            DB.connectToDb();
            DB.addcurriences(correctInsert);
            DB.closeConnectToDb();
        }
        

        public static string DownloadString(string address)
        {
            string text;
            using(var client = new WebClient())
            {
                text = client.DownloadString(address);
            }
            return text;
        }
    }
}
