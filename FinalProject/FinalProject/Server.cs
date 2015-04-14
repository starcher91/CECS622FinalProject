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
        public Queue<Customer> queue;
        private Random r;

        public Server(int passedID, Random r)
        {
            this.ID = passedID;
            this.r = r;
        }
    }
}
