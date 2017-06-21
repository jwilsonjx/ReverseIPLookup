using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseLookup.Helpers;

namespace ReverseLookup
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> IPAddresList = FileParser.GetIPAddressList();
            List<string> hostNames = new List<string>();

            foreach (string ipAddress in IPAddresList)
            {
                hostNames.Add(IPLookup.GetHostName(ipAddress));
            }

            FileWriter.CreateOutputFile(hostNames);
        }
    }
}
