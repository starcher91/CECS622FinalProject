using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Simulator
    {
        #region Member Variables/Constructor
        public string Model;
        public int numCust, numServers;
        public List<Server> servers;
        public List<Customer> outCustomerQueue;

        private static double MeanInterarrivalTime, MeanServiceTime, SIGMA;

        private Random r = new Random();

        public Simulator(string model, int numCust, int numServers, double interarrivalTime, double serviceTime, double sigma)
        {
            this.Model = model;
            this.numCust = numCust;
            this.numServers = numServers;

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
                case "MultiServer MultiQueue w/ Smart Queue":
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

            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(rand1)) * Math.Sin(2.0 * Math.PI * rand2);
            return mean + sigma * sigma * randStdNormal;
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

        private Server nextAvailableServer(Customer customer)
        {
            double shortestTime = double.MaxValue;
            Server nextAvailable = new Server(-1);
            foreach (Server s in servers)
            {
                if (s.customersServed.Count == 0)
                {
                    return s;
                }
                else if (s.customersServed[s.customersServed.Count - 1].departureTime < customer.arrivalTime)
                {
                    return s;
                }

                if (s.customersServed[s.customersServed.Count - 1].departureTime - customer.arrivalTime < shortestTime)
                {
                    nextAvailable = s;
                    shortestTime = s.customersServed[s.customersServed.Count - 1].departureTime -
                                   customer.arrivalTime;
                }
            }
            return nextAvailable;
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

            //calculate stats
            servers[0].sumServerSpecificStats();

            //calculate in context of whole simulation
            servers[0].avgWaitTime = servers[0].avgWaitTime/outCustomerQueue.Count;
            servers[0].probWaiting = servers[0].probWaiting/outCustomerQueue.Count;
            servers[0].probServerIdle = servers[0].probServerIdle/outCustomerQueue[outCustomerQueue.Count - 1].departureTime;
            servers[0].avgServiceTime = servers[0].avgServiceTime/outCustomerQueue.Count;
            servers[0].avgServerUtilization = servers[0].avgServerUtilization/
                                              outCustomerQueue[outCustomerQueue.Count - 1].departureTime;
            servers[0].avgTimeBetweenArrivals = servers[0].avgTimeBetweenArrivals/outCustomerQueue.Count;
            servers[0].avgTimeCustomerSpendsInSystem = servers[0].avgTimeCustomerSpendsInSystem/outCustomerQueue.Count;
            //no processing needed for throughput
            servers[0].avgQueueLength = servers[0].avgQueueLength/outCustomerQueue.Count;
            servers[0].avgNumInSystem = servers[0].avgNumInSystem/(outCustomerQueue.Count - 1);
            //no processing needed for idle times
        }

        private void MultiServerSimulation()
        {
            servers = new List<Server>();
            for (int i = 0; i < numServers; i++)
            {
                servers.Add(new Server(i));
            }

            List<Customer> customerQueue = generateCustomers();

            outCustomerQueue = new List<Customer>();

            int modServerIndex;
            //assign the customers to the server queues
            for (int i = 0; i < customerQueue.Count; i++)
            {
                modServerIndex = i%servers.Count; //iteratively assigns each customer to the next server, and the modulus function wraps it back around to the beginning

                //put customer in server queue, and process
                servers[modServerIndex].processCustomer(customerQueue[i]);

                //insert customer into final stored list
                outCustomerQueue.Add(customerQueue[i]);
            }

            double endTime = outCustomerQueue.Max(x => x.departureTime);
            //calculate single server stats
            foreach (Server s in servers)
            {
                s.sumServerSpecificStats();
                s.avgWaitTime = s.avgWaitTime / s.customersServed.Count;
                s.probWaiting = s.probWaiting / s.customersServed.Count;
                s.probServerIdle = s.probServerIdle / endTime;
                s.avgServiceTime = s.avgServiceTime / s.customersServed.Count;
                s.avgServerUtilization = s.avgServerUtilization /endTime;
                s.avgTimeBetweenArrivals = s.avgTimeBetweenArrivals / s.customersServed.Count;
                s.avgTimeCustomerSpendsInSystem = s.avgTimeCustomerSpendsInSystem / s.customersServed.Count;
                //no processing needed for throughput
                s.avgQueueLength = s.avgQueueLength/s.customersServed.Count;
                s.avgNumInSystem = s.avgNumInSystem / s.customersServed.Count;
                //no processing needed for idle times
            }
        }

        private void MultiServerMultiQueue()
        {
            servers = new List<Server>();
            for (int i = 0; i < numServers; i++)
            {
                servers.Add(new Server(i));
            }

            //generate customers
            var customers = generateCustomers();

            //create queues
            List<List<Customer>> queues = new List<List<Customer>>();
            for (int i = 0; i < numServers; i++)
            {
                queues.Add(new List<Customer>());
            }

            //add customers to queues
            int randQueue;
            for (int i = 0; i < customers.Count; i++)
            {
                randQueue = r.Next(0, queues.Count);
                queues[randQueue].Add(customers[i]);
            }

            outCustomerQueue = new List<Customer>();

            //assign the customers to the server queues
            for(int i = 0; i < queues.Count; i++)
            {
                for (int j = 0; j < queues[i].Count; j++)
                {
                    //process customer
                    servers[i].processCustomer(queues[i][j]);

                    //add most recently added customer to outCustomerQueue
                    outCustomerQueue.Add(queues[i][j]);
                }
            }
            //sort for display
            outCustomerQueue = outCustomerQueue.OrderBy(x => x.ID).ToList();

            double endTime = outCustomerQueue.Max(x => x.departureTime);
            //calculate single server stats
            foreach (Server s in servers)
            {
                s.sumServerSpecificStats();
                s.avgWaitTime = s.avgWaitTime / s.customersServed.Count;
                s.probWaiting = s.probWaiting / s.customersServed.Count;
                s.probServerIdle = s.probServerIdle / endTime;
                s.avgServiceTime = s.avgServiceTime / s.customersServed.Count;
                s.avgServerUtilization = s.avgServerUtilization / endTime;
                s.avgTimeBetweenArrivals = s.avgTimeBetweenArrivals / s.customersServed.Count;
                s.avgTimeCustomerSpendsInSystem = s.avgTimeCustomerSpendsInSystem / s.customersServed.Count;
                //no processing needed for throughput
                s.avgQueueLength = s.avgQueueLength / s.customersServed.Count;
                s.avgNumInSystem = s.avgNumInSystem / s.customersServed.Count;
                //no processing needed for idle times
            }
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
            var customers = generateCustomers();

            //create queues
            List<List<Customer>> queues = new List<List<Customer>>();
            for (int i = 0; i < numServers; i++)
            {
                queues.Add(new List<Customer>());
            }

            //add customers to queues
            for (int i = 0; i < customers.Count; i++)
            {
                queues[i % queues.Count].Add(customers[i]);
            }

            outCustomerQueue = new List<Customer>();

            int randQueue;
            Customer customer = new Customer(-1);
            for (int i = 0; i < numCust; i++)
            {
                //find queue that contains unprocessed customer
                randQueue = r.Next(0, queues.Count);
                while (queues[randQueue].TrueForAll(x => x.processed))
                {
                    randQueue = r.Next(0, queues.Count);
                }

                //gets next unprocessed customer from a random queue
                for (int j = 0; j < queues[randQueue].Count; j++)
                {
                    if (!queues[randQueue][j].processed)
                    {
                        customer = queues[randQueue][j];
                        break;
                    }
                }

                //gets next available server, and processes the customer
                nextAvailableServer(customer).processCustomer(customer);

                //add to Queue for display
                outCustomerQueue.Add(customer);
            }
            outCustomerQueue = outCustomerQueue.OrderBy(x => x.departureTime).ToList();

            double endTime = outCustomerQueue.Max(x => x.departureTime);
            //calculate single server stats
            foreach (Server s in servers)
            {
                s.sumServerSpecificStats();
                s.avgWaitTime = s.avgWaitTime / s.customersServed.Count;
                s.probWaiting = s.probWaiting / s.customersServed.Count;
                s.probServerIdle = s.probServerIdle / endTime;
                s.avgServiceTime = s.avgServiceTime / s.customersServed.Count;
                s.avgServerUtilization = s.avgServerUtilization / endTime;
                s.avgTimeBetweenArrivals = s.avgTimeBetweenArrivals / s.customersServed.Count;
                s.avgTimeCustomerSpendsInSystem = s.avgTimeCustomerSpendsInSystem / s.customersServed.Count;
                //no processing needed for throughput
                s.avgQueueLength = s.avgQueueLength / s.customersServed.Count;
                s.avgNumInSystem = s.avgNumInSystem / s.customersServed.Count;
                //no processing needed for idle times
            }
        }
        #endregion
    }
}
