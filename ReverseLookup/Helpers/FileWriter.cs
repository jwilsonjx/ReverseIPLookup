using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ReverseLookup.Models;

namespace ReverseLookup.Helpers
{
    public static class FileWriter
    {
        public static void CreateOutputFile(List<IPData> IPData)
        {
            using (CsvFileWriter writer = new CsvFileWriter("SiteVisitorData.csv"))
            {
                CsvRow header = new CsvRow();
                header.Add("IP_Address");
                header.Add("Organization");
                header.Add("WhoIsCustomerName");
                header.Add("WhoIsOrgName");
                header.Add("City");
                header.Add("Zip");
                header.Add("Country");
                header.Add("CountryCode");
                header.Add("ISP");
                header.Add("Latitude");
                header.Add("Longitude");
                header.Add("Region");
                header.Add("RegionName");
                header.Add("TimeZone");
                writer.WriteRow(header);

                foreach (IPData item in IPData)
                {
                    try
                    {
                        CsvRow row = new CsvRow();
                        row.Add(item.Query ?? string.Empty);
                        row.Add(item.Org ?? string.Empty);
                        row.Add(item.WhoIsName ?? string.Empty);
                        row.Add(item.WhoIsOrganization ?? string.Empty);
                        row.Add(item.City ?? string.Empty);
                        row.Add(item.Zip ?? string.Empty);
                        row.Add(item.Country ?? string.Empty);
                        row.Add(item.CountryCode ?? string.Empty);
                        row.Add(item.ISP ?? string.Empty);
                        row.Add(item.Lat ?? string.Empty);
                        row.Add(item.Lon ?? string.Empty);
                        row.Add(item.Region ?? string.Empty);
                        row.Add(item.RegionName ?? string.Empty);
                        row.Add(item.TimeZone ?? string.Empty);
                        writer.WriteRow(row);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}
