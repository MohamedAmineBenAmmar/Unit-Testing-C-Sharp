using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        // Testing simple string
        public string SendPing()
        {
            // This is just a simulation of sending a ping
            return "Success: Ping Sent!";
        }

        // Testing a method that takes arguments
        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        // Testing DateTime objects
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        // Testing objects
        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        // Testing IEnumerable
        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingsOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment= true,
                    Ttl= 1
                },
                new PingOptions()
                {
                    DontFragment= true,
                    Ttl= 1
                },
                new PingOptions()
                {
                    DontFragment= true,
                    Ttl= 1
                }
            };

            return pingsOptions;
        }
    }
}
