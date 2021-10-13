using System.Net;

namespace socket.App.Utils
{
    public static class IPAddressFinder
    {
        public static IPAddress GetLocalIPAddress()
        {
            IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
            //IPAddress ipAddress = IPAddress.Parse("192.168.0.88");
            // IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            // IPAddress ipAddress = ipHostInfo.AddressList[0];
            return ipAddress;
        }
    }
}