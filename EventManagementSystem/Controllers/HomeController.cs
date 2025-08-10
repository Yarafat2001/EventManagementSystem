using EventManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Required for ToListAsync()
using System.Threading.Tasks;

namespace EventManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        // The constructor gets the database context via dependency injection
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // This Index action fetches the events and passes them to the view
        public async Task<IActionResult> Index()
        {
            // Fetch all events from the database into a list.
            var allEvents = await _context.Events.ToListAsync();

            // Pass the list of events to the View.
            // If no events are found, this will be an empty list, NOT null.
            return View(allEvents);
        }

        // ... other actions like Privacy ...
    }
}