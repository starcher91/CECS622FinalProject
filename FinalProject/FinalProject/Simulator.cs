using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Simulator
    {
        #region Member Variables/Constructor
        public string Model;
        public int numCust, numServers, numTrials;
        public List<Server> servers;
        public List<Customer> outCustomerQueue;

        private static double Clock, MeanInterarrivalTime, MeanServiceTime, SIGMA, LastEventTime, TotalBusy, MaxQueueLength, SumResponseTime;
        private static long NumberInService, TotalCustomers, NumDepartures, LongService;

        private Random r = new Random();

        public Simulator(string Model, int numCust, int numServers, int numTrials, double interarrivalTime, double serviceTime, double sigma)
        {
            this.Model = Model;
            this.numCust = numCust;
            this.numServers = numServers;
            this.numTrials = numTrials;

            Clock = 0.0;
            MeanInterarrivalTime = interarrivalTime;
            MeanServiceTime = serviceTime;
            SIGMA = sigma;
        }
        #endregion

        #region main program
        public void runSimulator()
        {
            switch(Model)
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
            }
        }
        #endregion

        #region global helper methods
        private double BoxMuller(double mean, double sigma)
        {
            double rand1 = r.NextDouble();
            double rand2 = r.NextDouble();

            double randStdNormal = Math.Sqrt(Math.Abs(-2.0 * Math.Log(rand1) * Math.Sin(2.0 * Math.PI * rand2)));
            return mean + sigma * randStdNormal;
        }

        private List<Customer> generateCustomers()
        {
            List<Customer> customerQueue = new List<Customer>();

            //generate the customer data
            for (int i = 0; i < numCust; i++)
            {
                customerQueue.Add(new Customer(i));

                //generates arrival times
                if (i == 0)
                {
                    customerQueue[i].arrivalTime = 0;
                }
                else
                {
                    customerQueue[i].arrivalTime = customerQueue[i - 1].arrivalTime +
                                                   BoxMuller(MeanInterarrivalTime, SIGMA);
                }
                //generates service times
                customerQueue[i].serviceTime = BoxMuller(MeanServiceTime, SIGMA);
            }
            return customerQueue;
        }
        #endregion

        #region Simulator Methods
        private void SingleServerSimulation()
        {
            List<Customer> customerQueue = generateCustomers();
            outCustomerQueue = new List<Customer>(); //instantiate class level variable
            servers = new List<Server>();
            servers.Add(new Server(0)); //instantiate sole server
            foreach (Customer c in customerQueue)
            {
                outCustomerQueue.Add(servers[0].processCustomer(c));
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
            servers = new List<Server>();

            //add the servers
            for (int i = 0; i < numServers; i++)
            {
                servers.Add(new Server(i));
            }

            //generate customers
            List<Customer> customerQueue = generateCustomers();

            outCustomerQueue = new List<Customer>();

            for (int i = 0; i < customerQueue.Count; i++)
            {
                //find an open server and add customer to it
                bool noneOpen = true;
                double shortestTime = double.MaxValue;
                Server nextAvailable = new Server(-1);
                foreach (Server s in servers)
                {
                    if (s.customersServed.Count == 0)
                    {
                        noneOpen = false;
                        outCustomerQueue.Add(s.processCustomer(customerQueue[i]));
                        break;
                    }
                    else if (s.customersServed[s.customersServed.Count - 1].departureTime < customerQueue[i].arrivalTime)
                    {
                        noneOpen = false;
                        outCustomerQueue.Add(s.processCustomer(customerQueue[i]));
                        break;
                    }

                    if (s.customersServed[s.customersServed.Count - 1].departureTime - customerQueue[i].arrivalTime < shortestTime)
                    {
                        nextAvailable = s;
                        shortestTime = s.customersServed[s.customersServed.Count - 1].departureTime -
                                       customerQueue[i].arrivalTime;
                    }
                }

                if (noneOpen)
                {
                    outCustomerQueue.Add(nextAvailable.processCustomer(customerQueue[i]));
                }
            }
        }
        #endregion
    }
}
