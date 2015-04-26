using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Customer
    {
        public int ID { get; set; }
        public double arrivalTime { get; set; }
        public double serviceTime { get; set; }
        public double waitTime { get; set; }
        public double departureTime { get; set; }
        public double inSystemTime { get; set; }
        public double serverProcessedID { get; set; }

        public Customer(int Id)
        {
            this.ID = Id;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
