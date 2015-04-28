using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Server
    {
        public int ID { get; set; }
        public List<Customer> customersServed = new List<Customer>();
        public bool busy;
        public double avgWaitTime { get; set; }
        public double timeSpentIdle = 0;
        public double idleInstances = 0;
        public double probWaiting { get; set; }
        public double probServerIdle { get; set; }
        public double avgServiceTime { get; set; }
        public double avgServerUtilization { get; set; }
        public double avgTimeBetweenArrivals { get; set; }
        public double avgTimeCustomerSpendsInSystem { get; set; }
        public double throughput { get; set; }
        public double avgQueueLength { get; set; }
        public double avgNumInSystem { get; set; }
        public double avgIdleTime { get; set; }

        public Server(int passedID)
        {
            this.ID = passedID;
            busy = false;
        }

        public Server(Server s)
        {
            this.ID = s.ID;
            this.customersServed = new List<Customer>(s.customersServed);
            this.busy = s.busy;
            avgWaitTime = 0;
            probWaiting = 0;
            probServerIdle = 0;
            avgServiceTime = 0;
            avgServerUtilization = 0;
            avgTimeBetweenArrivals = 0;
            avgTimeCustomerSpendsInSystem = 0;
            avgQueueLength = 0;
        }

        public override string ToString()
        {
            return ID.ToString() + " " + String.Join(", ", customersServed);
        }

        public Customer processCustomer(Customer customer)
        {
            if (customersServed.Count == 0)
            {
                customer.waitTime = 0;
                customersServed.Add(customer);
            }
            else if (customer.arrivalTime < customersServed[customersServed.Count - 1].departureTime) //another customer arrives before they are out
            {
                customer.waitTime = customersServed[customersServed.Count - 1].departureTime - customer.arrivalTime;
                customersServed.Add(customer);
            }
            else
            {
                customer.waitTime = 0;
                customersServed.Add(customer);
            }

            customer.departureTime = customer.arrivalTime + customer.waitTime +
                                                customer.serviceTime;
            customer.inSystemTime = customer.serviceTime + customer.waitTime;
            customer.serverProcessedID = this.ID;
            customer.processed = true;

            return customer;
        }

        public void sumServerSpecificStats()
        {
            for(int i = 0; i < customersServed.Count; i++)
            {
                //sum wait times
                avgWaitTime += customersServed[i].waitTime;

                //increment probability of waiting
                if (customersServed[i].waitTime > 0)
                    probWaiting++;

                //increment probability of server being idle
                if (i > 0)
                {
                    if (customersServed[i].arrivalTime > customersServed[i - 1].departureTime)
                        probServerIdle += customersServed[i].arrivalTime - customersServed[i - 1].departureTime;
                }
                else if (customersServed[0].arrivalTime > 0) //checks for server not processing the first arrival
                {
                    probServerIdle += customersServed[0].arrivalTime;
                }

                //sum service times
                avgServiceTime += customersServed[i].serviceTime;

                //sum server utilization
                avgServerUtilization += customersServed[i].serviceTime;

                //sum time between arrivals
                if (i > 0)
                {
                    avgTimeBetweenArrivals += customersServed[i].arrivalTime - customersServed[i - 1].arrivalTime;
                }

                //sum time spent in system
                avgTimeCustomerSpendsInSystem += customersServed[i].inSystemTime;

                
                int customerSpecificQueueLength = 0;
                if (i > 0)
                {
                    //sum queue length
                    int j = i - 1;
                    while (customersServed[i].arrivalTime < customersServed[j].departureTime && j > 0)
                    {
                        customerSpecificQueueLength++;
                        j--;
                    }
                    avgQueueLength += customerSpecificQueueLength;
                    avgNumInSystem += customerSpecificQueueLength + 1;

                    //establish idle time
                    if (customersServed[i].arrivalTime > customersServed[i - 1].departureTime)
                    {
                        timeSpentIdle += customersServed[i].arrivalTime - customersServed[i - 1].departureTime;
                        idleInstances++;
                    }
                }
            }
            //throughput
            throughput = customersServed.Count/
                         (customersServed[customersServed.Count - 1].departureTime - customersServed[0].arrivalTime);

            //average idle time
            if (idleInstances > 0)
                avgIdleTime = timeSpentIdle/idleInstances;
            else
                avgIdleTime = 0;
        }
    }
}
