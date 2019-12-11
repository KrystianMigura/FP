using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;


namespace Cantor.Controllers
{
    class CatchData
    {
       public CatchData() { }

        public void tryCatchData()
        {
            String xml = DownloadString(@"http://webtask.future-processing.com:8068/currencies");
            var obj = JObject.Parse(xml);
            Console.WriteLine(obj["items"][0]["name"]); // catch value from link
            Console.WriteLine(obj["publicationDate"]); // catch value from link!
  
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
