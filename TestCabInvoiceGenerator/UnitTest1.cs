using CabInvoiceGenerator;
using NUnit.Framework;

namespace TestCabInvoiceGenerator
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 100;

            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummery()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary excpectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(excpectedSummary, invoiceSummary);
        }
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummeryAndAverageFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary excpectedSummary = new InvoiceSummary(2, 30.0, 15);

            Assert.AreEqual(excpectedSummary, invoiceSummary);
        }
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummeryAndAddUserId()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRide("101", rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary("101");
            InvoiceSummary excpectedSummary = new InvoiceSummary(2, 30.0, "101");

            Assert.AreEqual(excpectedSummary, invoiceSummary);
        }
    }
}