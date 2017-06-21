using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReverseLookup.Helpers
{
    public static class FileWriter
    {
        public static void CreateOutputFile(List<string> hostNames)
        {
            foreach(string hostName in hostNames)
            {
                using (StreamWriter file = new StreamWriter("output.txt", true))
                {
                    file.WriteLine(hostName);
                }
            }
        }
    }
}
