using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();

            try
            {
                if(rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if(rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException("Invalid Ride Type", CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE);
            }
        }

        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM * time * COST_PER_TIME; 
            }
            catch(CabInvoiceException)
            {
                if(rideType.Equals(null))
                {
                    throw new CabInvoiceException("Invalid Ride", CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE);
                }
                if(distance <= 0)
                {
                    throw new CabInvoiceException("Invalid Distance", CabInvoiceException.ExceptionType.INVALID_DISTANCE);
                }
                if(time < 0)
                {
                    throw new CabInvoiceException("Invalid Time", CabInvoiceException.ExceptionType.INVALID_TIME);
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
}
