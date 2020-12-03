using HotelBooking.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HotelBooking
{
    [TestClass]
    public class UnitTest1
    {
        public BookingManager bm = new BookingManager();
        public DateTime today = DateTime.Now;

        // This unit test shows booking a room and the booking pass
        [TestMethod]
        public void CheckRoomByRoomNumberPass()
        {
            bool isAvailable = bm.IsRoomAvailable(101, today);

            if(isAvailable)
            {
                bm.AddBooking("potter", 101, today);
            }
            
            Assert.IsTrue(isAvailable);

        }

        // This unit test will show a fail when trying to book a room that is not available
        [TestMethod]
        public void CheckRoomByRoomNumberFail()
        {
            bool isAvailable = bm.IsRoomAvailable(101, today);
            if (isAvailable)
            {
                bm.AddBooking("potter", 101, today);
            }

            // here we are trying to book the room that was just booked above, we assume it will fail
            bool trySameRoom = bm.IsRoomAvailable(101, today);

            Assert.IsFalse(trySameRoom);

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

        // We would use this method to retrieve the list of available rooms so the clerk would know right away if the rooms were available
        public IEnumerable<int> getAvailableRooms(DateTime date)
        {
            // Since we already have a list of the rooms available, we can just return that :)
            return availableRooms;
        }

        // This method would be used to be able to add a room back to the list of available rooms.
        public void AddRoomBackToAvailable(int room)
        {
            int index = availableRooms.IndexOf(room);

            if(index == -1)
            {
                availableRooms.Add(room);
            }
        }
    }
}
