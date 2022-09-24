using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientUnSafe
    {
        #region Settings
        private const int port = 4004;
        private const string server = "26.23.34.159";
        #endregion

        protected internal Socket client = null;
        public ClientUnSafe(string ip)
        {
            byte[] data = new byte[256];
            IPHostEntry iphostInfo = Dns.GetHostEntry(ip);
            IPAddress ipAdress = iphostInfo.AddressList[0];
            IPEndPoint ipEndpoint = new IPEndPoint(ipAdress, 4004);
            client = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(ipEndpoint);
            }
            catch (Exception e) { }
        }
        public ClientUnSafe()
        {
            byte[] data = new byte[256];
            IPHostEntry iphostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAdress = iphostInfo.AddressList[0];
            IPEndPoint ipEndpoint = new IPEndPoint(ipAdress, 4004);
            client = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(ipEndpoint);
            }
            catch (Exception e) { }
        }
        protected internal string ReciveMessage()
        {
            if (client != null && client.Connected)
            {
                byte[] data = new byte[256];
                int m = client.Receive(data);
                string message = Encoding.ASCII.GetString(data);
                return message;
            }
            return null;
        }
        protected internal void SendMessage(string message)
        {
            if (client != null && client.Connected)
            {
                byte[] sendmsg = Encoding.UTF8.GetBytes(message + "\n");
                int n = client.Send(sendmsg);
            }
        }
    }
}
