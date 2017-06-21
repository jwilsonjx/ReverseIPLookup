using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ReverseLookup.Helpers
{
    public static class IPLookup
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string GetHostName(string ipAddress)
        {
            string hostName = string.Empty;

            try
            {
                IPAddress hostIPAddress = IPAddress.Parse(ipAddress);
                IPHostEntry hostInfo = Dns.GetHostByAddress(hostIPAddress);

                IPAddress[] address = hostInfo.AddressList;
                String[] alias = hostInfo.Aliases; // In case I want to do something with this later

                hostName = ("Host name : " + hostInfo.HostName);
            }
            catch (SocketException e)
            {
                Logger.Warn(ipAddress);
                Logger.Warn("SocketException");
                Logger.Warn("Source : " + e.Source);
                Logger.Warn("Message : " + e.Message);

            }
            catch (FormatException e)
            {
                Logger.Warn(ipAddress);
                Logger.Warn("FormatException");
                Logger.Warn("Source : " + e.Source);
                Logger.Warn("Message : " + e.Message);

            }
            catch (ArgumentNullException e)
            {
                Logger.Warn(ipAddress);
                Logger.Warn("ArgumentNullException");
                Logger.Warn("Source : " + e.Source);
                Logger.Warn("Message : " + e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(ipAddress);
                Logger.Warn("Exception");
                Logger.Warn("Source : " + e.Source);
                Logger.Warn("Message : " + e.Message);
            }

            return hostName;

        }
    }
}
