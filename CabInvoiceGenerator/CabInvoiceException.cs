using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException:Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDE,
            INVALID_USER_ID,
        }
        private ExceptionType type;
        public CabInvoiceException(string message, ExceptionType type):base(message)
        {
            this.type = type;
        }
    }
}
