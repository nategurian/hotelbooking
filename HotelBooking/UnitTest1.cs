using HotelBooking.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HotelBooking
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BookingManager bm = new BookingManager();
            DateTime today = DateTime.Now;

            bool isAvailable = bm.IsRoomAvailable(101, today);
            Console.WriteLine(isAvailable);
            if(isAvailable)
            {
                bm.AddBooking("potter", 101, today);
            }

        }
    }

    public class BookingManager: IBookingManager
    {
        List<int> availableRooms = new List<int>() { 101, 102, 201, 203 };

        public bool IsRoomAvailable(int room, DateTime date)
        {
            if(availableRooms.IndexOf(room) != -1)
            {
                return true;
            }

            return false;
        }

        public void AddBooking(string guest, int room, DateTime date)
        {
            // Checking to see if the room is still available
            int index = availableRooms.IndexOf(room);

            // If the room is available, we want to remove it from the list of available rooms.
            // When a guest checks out we would have another method that would add the room number back to the list of available rooms
            if(index != -1)
            {
                availableRooms.RemoveAt(index);
            }
            else
            {
                throw new Exception();
            }
        }

        public IEnumerable<int> getAvailableRooms(DateTime date)
        {
            // Since we already have a list of the rooms available, we can just return that :)
            return availableRooms;
        }
    }
}
