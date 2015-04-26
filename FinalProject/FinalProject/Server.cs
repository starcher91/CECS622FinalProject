using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Server
    {
        public int ID;
        public List<Customer> customersServed = new List<Customer>();
        public bool busy;

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
            return customer;
        }
    }
}
