using Microsoft.AspNetCore.Mvc;
using MeetingRoomApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MeetingRoomApp.Controllers
{
    public class HomeController : Controller
    {
        // Proqram işləyən müddətdə dataların qalması üçün static list
        private static List<Reservation> _reservations = new List<Reservation>
        {
            new Reservation { Id = 1, RoomNumber = "Otaq 401", Date = DateTime.Parse("2026-04-16"), Time = new TimeSpan(16, 15, 0) },
            new Reservation { Id = 2, RoomNumber = "Otaq 402", Date = DateTime.Parse("2026-04-17"), Time = new TimeSpan(14, 16, 0) }
        };

        // Səhifəni yükləyəndə siyahını göndərir
        public IActionResult Index()
        {
            return View(_reservations);
        }

        // Yeni məlumat əlavə edir
        [HttpPost]
        public IActionResult AddReservation(string RoomNumber, DateTime Date, TimeSpan Time)
        {
            int newId = _reservations.Any() ? _reservations.Max(r => r.Id) + 1 : 1;
            
            var newRes = new Reservation
            {
                Id = newId,
                RoomNumber = RoomNumber,
                Date = Date,
                Time = Time
            };

            _reservations.Add(newRes);
            return RedirectToAction("Index");
        }

        // Məlumatı silir
        [HttpPost]
        public IActionResult DeleteReservation(int id)
        {
            var item = _reservations.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _reservations.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}
