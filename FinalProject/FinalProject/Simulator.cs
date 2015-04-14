using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Simulator
    {
        public string Model;
        public int numCust, numServers, numTrials;
        private List<Server> servers = new List<Server>();

        public void Simulator(string Model, int numCust, int numServers, int numTrials)
        {
            this.Model = Model;
            this.numCust = numCust;
            this.numServers = numServers;
            this.numTrials = numTrials;
        }

        public void runSimulator()
        {
            if(numServers > 1)
            {
                for(int i = 0; i < numServers; i++)
                {
                    servers.Add(new Server(i));
                }
            }
        }
    }
}
