using System.Net;
using System.Net.Sockets;

namespace Identity.Helpers
{
    public class IpHelper
    {
        public static string GetIpAddres()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
    }
}
