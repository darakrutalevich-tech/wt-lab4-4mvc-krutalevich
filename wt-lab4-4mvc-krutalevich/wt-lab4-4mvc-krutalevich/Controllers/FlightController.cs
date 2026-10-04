using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_krutalevich.Models;

namespace wt_lab4_4mvc_krutalevich.Controllers
{
    public class FlightController : Controller
    {
        // GET: /Flight/Index  или  /Flight
        public IActionResult Index()
        {
            var flights = FlightRepository.Flights;
            return View(flights);
        }

        // GET: /Flight/Details/x
        public IActionResult Details(int id)
        {
            var flight = FlightRepository.Flights.FirstOrDefault(f => f.Id == id);
            if (flight == null)
                return NotFound(); // вернёт HTTP 404

            return View(flight);
        }

        // GET: /Flight/Create — показать пустую форму
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Flight/Create — принять данные формы
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return View(flight);
            }

            flight.Id = FlightRepository.NextId();
            FlightRepository.Flights.Add(flight);
            return RedirectToAction("Index");
        }

        // GET: /Flight/Edit/x — показать форму редактирования
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var flight = FlightRepository.Flights.FirstOrDefault(f => f.Id == id);
            if (flight == null)
                return NotFound();

            return View(flight);
        }

        // POST: /Flight/Edit/x - принять изменения
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return View(flight);
            }

            var existing = FlightRepository.Flights.FirstOrDefault(f => f.Id == flight.Id);
            if (existing == null)
                return NotFound();

            existing.FlightNumber = flight.FlightNumber;
            existing.Departure = flight.Departure;
            existing.Arrival = flight.Arrival;
            existing.Price = flight.Price;
            existing.IsAvailable = flight.IsAvailable;

            return RedirectToAction("Index");
        }

        // GET: /Flight/Delete/x — страница подтверждения удаления
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var flight = FlightRepository.Flights.FirstOrDefault(f => f.Id == id);
            if (flight == null)
                return NotFound();

            return View(flight);
        }

        // POST: /Flight/Delete/x — удалить рейс
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var flight = FlightRepository.Flights.FirstOrDefault(f => f.Id == id);
            if (flight == null)
                return NotFound();

            FlightRepository.Flights.Remove(flight);
            return RedirectToAction("Index");
        }
    }
}
