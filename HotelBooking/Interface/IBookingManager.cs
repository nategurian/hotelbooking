using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Interface
{
   public interface IBookingManager
    {
        /**
        * Return true if there is no booking for the given room on the date,
        * otherwise false
        */
        bool IsRoomAvailable(int room, DateTime date);

        /**
        * Add a booking for the given guest in the given room on the given
        * date. If the room is not available, throw a suitable Exception.
        */
        void AddBooking(string guest, int room, DateTime date);

        /**
        * Return a list of all the available room numbers for the given date
        */
        IEnumerable<int> getAvailableRooms(DateTime date);

        /**
        * Add this the newly checked out room back to the list of available rooms 
        */
        void AddRoomBackToAvailable(int room);
    }
}
