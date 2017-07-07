using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLookup.Models
{
    public class IPData
    {
        public string AS { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string ISP { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Org { get; set; }
        public string Corporation { get; set; }
        public string Query { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string Status { get; set; }
        public string TimeZone { get; set; }
        public string Zip { get; set; }
        public string WhoIsName { get; set; }
        public string WhoIsOrganization { get; set; }
    }
}
