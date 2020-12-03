using HotelBooking.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HotelBooking
{
    [TestClass]
    public class UnitTest1
    {
        public BookingManager bm = new BookingManager();
        public DateTime date = new DateTime(2020, 5, 11);
        private readonly object bookingLock = new object();

        // This unit test shows booking a room and the booking pass
        [TestMethod]
        public void CheckRoomByRoomNumberPass()
        {
            bool isAvailable = bm.IsRoomAvailable(203, date);

            if (isAvailable)
            {
                lock(bookingLock)
                {
                    try
                    {
                        bm.AddBooking("potter", 203, date);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("This room is already booked, please try another room number");
                    }
                    
                }
    
            }

            Assert.IsTrue(isAvailable);

        }

        // This unit test will show a fail when trying to book a room that is not available
        [TestMethod]
        public void CheckRoomByRoomNumberFail()
        {
            bool isAvailable = bm.IsRoomAvailable(101, date);
            Assert.IsFalse(isAvailable);
        }
    }
}
