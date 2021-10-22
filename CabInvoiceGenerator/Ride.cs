using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double distance { get; set; }
        public int time { get; set; }

        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
