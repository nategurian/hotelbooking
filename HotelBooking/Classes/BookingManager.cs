using HotelBooking.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Classes
{
    public class BookingManager : IBookingManager
    {
        List<Room> Rooms = new List<Room>() {
                    new Room(101, new DateTime(2020, 10, 15)),
                    new Room(102, new DateTime(2020, 12, 10)),
                    new Room(201, new DateTime(2020, 10, 10)),
                    new Room(203, new DateTime(2020, 5, 11)) 
                };

        List<Booking> Bookings = new List<Booking>();
        

        public bool IsRoomAvailable(int roomNum, DateTime date)
        {
            Room room = Rooms.Find(room => room.RoomNumber == roomNum && room.AvailableDate == date);
            if(room != null)
            {
                return true;
            }

            return false;
        }

        public void AddBooking(string guest, int roomNum, DateTime date)
        {
            // Add new Booking to booking list
            Booking booking = new Booking();
            booking.CheckInDate = date;
            booking.SurName = guest;
            booking.RoomNumber = roomNum;

            // Double check to make sure there is no booking with this room number
            Booking bk = Bookings.Find(b => b.RoomNumber == roomNum);
            if(bk == null)
            {
                Bookings.Add(booking);
            }
            else
            {
                throw new Exception("Room already booked");
            }
           

            // Once added, we need to nullify available date for room in the Rooms list
            Room room = Rooms.Find(room => room.RoomNumber == roomNum);
            room.AvailableDate = null;
        }

        // We would use this method to retrieve the list of available rooms so the clerk would know right away if the rooms were available
        public IEnumerable<Room> getAvailableRooms(DateTime date)
        {
            return Rooms.FindAll(r => r.AvailableDate != null && r.AvailableDate == date);
        }
    }
}
