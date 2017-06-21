using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReverseLookup.Helpers
{
    public static class FileParser
    {
        public static List<string> GetIPAddressList()
        {
            List<string> IPAddressList = new List<string>();

            int counter = 0;
            string line;

            StreamReader file = new StreamReader("list.txt");

            while ((line = file.ReadLine()) != null)
            {
                int countedDots = line.Count(x => x == '.');

                if(countedDots == 3) //validate IP Address
                {
                    IPAddressList.Add(line);
                }
                
                counter++;
            }

            file.Close();

            return IPAddressList;
        }
    }
}
