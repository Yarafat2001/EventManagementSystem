using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
public class TicketsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TicketsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // This action now fetches the user's tickets and returns them to the view
    public async Task<IActionResult> MyTickets()
    {
        var userId = _userManager.GetUserId(User);

        var userTickets = await _context.Tickets
                                .Where(t => t.UserId == userId)
                                .Include(t => t.TicketType)       // Include related TicketType data
                                .ThenInclude(tt => tt.Event)      // Then include related Event data
                                .OrderByDescending(t => t.PurchaseDate)
                                .ToListAsync();

        return View(userTickets);
    }
}