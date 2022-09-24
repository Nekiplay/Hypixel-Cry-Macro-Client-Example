using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client
{
    public class Player
    {
        ClientUnSafe client;
        public Player(ClientUnSafe client)
        {
            this.client = client;
        }
        public void SetAngle(float yaw, float pitch)
        {
            client.SendMessage("Set angle: yaw:" + yaw + " pitch:" + pitch);
        }
        public void DownKey(MinecraftKeyBinding key)
        {
            int keycode = (int)key;
            client.SendMessage("Down key:" + keycode);
        }
        public void UpKey(MinecraftKeyBinding key)
        {
            int keycode = (int)key;
            client.SendMessage("Up key:" + keycode);
        }
        public void AddChatMessage(string message)
        {
            client.SendMessage("AddChatText:" + message);
        }
        public void SendChatMessage(string message)
        {
            client.SendMessage("SendChatMessage:" + message);
        }
        public Location GetCords()
        {
            client.SendMessage("GetPos");
            string r = client.ReciveMessage();
            Match m = Regex.Match(r.Trim(), "x:(.*) y:(.*) z:(.*)");
            if (m.Success)
            {
                double x = double.Parse(m.Groups[1].Value.Trim().Replace(".", ","));
                double y = double.Parse(m.Groups[2].Value.Trim().Replace(".", ","));
                double z = double.Parse(m.Groups[3].Value.Trim().Replace(".", ","));
                return new Location(x, y,z);
            }
            return null;
        }

        public string GetName()
        {
            client.SendMessage("GetNickname");
            string r = client.ReciveMessage();
            return r;
        }
    }
}
