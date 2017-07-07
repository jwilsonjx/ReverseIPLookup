using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseLookup.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReverseLookup.Models;

namespace ReverseLookup
{
    class Program
    {    
        static void Main(string[] args)
        {
            string GeoIPAPI = "http://ip-api.com/json/";
            string WhoIsIPAPI = "http://whois.arin.net/rest/ip/";

            List<string> IPAddresList = FileParser.GetIPAddressList();
            List<IPData> ipDataList = new List<IPData>();

            foreach (string ipAddress in IPAddresList)
            {
                string whoIsJson = WhoIsLookup.GET(WhoIsIPAPI + ipAddress);
                string geoJson = IPGeoLookup.GET(GeoIPAPI + ipAddress);

                JObject o = JObject.Parse(whoIsJson);
                string whoIsCustomerName = (string)o.SelectToken("net.customerRef.@name");
                string whoIsOrganization = (string)o.SelectToken("net.orgRef.@name");

                IPData geoIPdata = JsonConvert.DeserializeObject<IPData>(geoJson);

                geoIPdata.WhoIsName = whoIsCustomerName;
                geoIPdata.WhoIsOrganization = whoIsOrganization;

                ipDataList.Add(geoIPdata);    
            }

            FileWriter.CreateOutputFile(ipDataList);
        }
    }
}
