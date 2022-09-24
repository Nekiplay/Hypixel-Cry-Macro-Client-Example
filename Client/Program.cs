using System;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace Client // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Minecraft minecraft = new Minecraft();
            DateTime start = DateTime.MinValue;
            Thread thread = new Thread(() =>
            {
                start = DateTime.Now;
                minecraft.player.AddChatMessage(ColorText.RED + "Макрос включен");
                Location cord = minecraft.player.GetCords();
                if (cord != null)
                {
                    Console.WriteLine("\"X: " + cord.x + " Y:" + cord.y + " Z:" + cord.z + "\"");
                }
            });
            thread.Start();
            Console.ReadLine();
        }

        public static string ToReadableAgeString(TimeSpan span)
        {
            return string.Format("{0:0}", span.Days / 365.25);
        }
        public static string ToReadableString(TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0}d, ", span.Days, span.Days == 1 ? string.Empty : "s") : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0}h, ", span.Hours, span.Hours == 1 ? string.Empty : "s") : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0}m, ", span.Minutes, span.Minutes == 1 ? string.Empty : "s") : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0}s", span.Seconds, span.Seconds == 1 ? string.Empty : "s") : string.Empty);
            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);
            if (string.IsNullOrEmpty(formatted)) formatted = "0s";
            return formatted;
        }
    }
}