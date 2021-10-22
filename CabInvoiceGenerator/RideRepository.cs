using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if(!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException("Null Rides", CabInvoiceException.ExceptionType.NULL_RIDE);
            }
        }

        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch
            {
                throw new CabInvoiceException("Invalid User-Id", CabInvoiceException.ExceptionType.INVALID_USER_ID);
            }
        }
    }
}
