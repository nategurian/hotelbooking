using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Classes
{
    public class Room
    {
        public Room(int number, DateTime date)
        {
            RoomNumber = number;
            AvailableDate = date;
        }
        public int RoomNumber { get; set; }
        public DateTime? AvailableDate { get; set; }
    }
}
