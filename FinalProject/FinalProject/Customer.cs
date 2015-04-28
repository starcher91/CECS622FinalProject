using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Customer
    {
        public int ID { get; set; }
        public double arrivalTime { get; set; }
        public double serviceTime { get; set; }
        public double waitTime { get; set; }
        public double departureTime { get; set; }
        public double inSystemTime { get; set; }
        public int serverProcessedID { get; set; }
        public bool processed = false;

        public Customer(int Id)
        {
            this.ID = Id;
        }

        public Customer(Customer c)
        {
            this.ID = c.ID;
            this.arrivalTime = c.arrivalTime;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
