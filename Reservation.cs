using System;

namespace MeetingRoomApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
