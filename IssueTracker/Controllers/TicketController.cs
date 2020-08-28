using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketController(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
