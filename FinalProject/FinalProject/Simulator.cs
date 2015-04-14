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
        private Queue<Customer> customerQueue = new Queue<Customer>();

        private static double Clock, MeanInterarrivalTime, MeanServiceTime, SIGMA, LastEventTime, TotalBusy, MaxQueueLength, SumResponseTime;
        private static long NumCustomers, QueueLength, NumberInService, TotalCustomers, NumDepartures, LongService;

        private Random r = new Random();

        public void Simulator(string Model, int numCust, int numServers, int numTrials)
        {
            this.Model = Model;
            this.numCust = numCust;
            this.numServers = numServers;
            this.numTrials = numTrials;

            Clock = 0.0;
            MeanInterarrivalTime = 4.5;
            MeanServiceTime = 3.2;
            SIGMA = 0.6;
        }

        public void runSimulator()
        {
            switch(this.Model)
            {
                case "Single Server":
                    SingleServerSimulation();
                    break;
                case "MultiServer":
                    MultiServerSimulation();
                    break;
                case "MultiServer MultiQueue":
                    MultiServerMultiQueue();
                    break;
                case "MultiServer w/ SmartQueue":
                    MultiServerSmartQueue();
                    break;
                default:
                    break;
            }
                
        }

        private void SingleServerSimulation()
        {
            //add the server
            servers.Add(new Server(1, r));

            while(numCust > 0)
            {

            }
        }

        private void MultiServerSimulation()
        {

        }

        private void MultiServerMultiQueue()
        {

        }

        private void MultiServerSmartQueue()
        {

        }
    }
}
