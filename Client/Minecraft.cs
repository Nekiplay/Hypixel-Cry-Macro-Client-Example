using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Minecraft
    {

        private ClientUnSafe client;
        public Minecraft()
        {
            client = new ClientUnSafe();
            player = new Player(client);
        }
        public Minecraft(string ip)
        {
            client = new ClientUnSafe(ip);
            player = new Player(client);
        }

        public Player player;

    }
}
