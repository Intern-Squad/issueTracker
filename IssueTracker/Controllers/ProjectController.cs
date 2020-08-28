using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IssueTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectController(ApplicationDbContext Dbcontext)
        {
            _dbContext = Dbcontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var projects = _dbContext.Projects.ToList();

            return View(projects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Message = "Create";
            return View("projectform");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            //Assigning the project created date and updated date as current system datetime
            project.createdDate = System.DateTime.Now;
            project.updatedDate = System.DateTime.Now;


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedUser = _dbContext.Users.Find(userId);
            project.Users.Add(loggedUser);
            
            await _dbContext.Projects.AddAsync(project);
            
            await _dbContext.SaveChangesAsync();
            
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null) return BadRequest();

                var project = _dbContext.Projects.Find(id);

                if (project != null) return View(project);

                return NotFound();
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();

            var project = _dbContext.Projects.Find(id);

            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                _dbContext.SaveChanges();
                return RedirectToAction("index", "project");
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Message = "Edit";
            var project = await _dbContext.Projects.FindAsync(id);
            return View("projectform", project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            if (project == null) return BadRequest();

            var projectInDb = _dbContext.Projects.Find(project.id);

            projectInDb.name = project.name;
            projectInDb.description = project.description;
            projectInDb.updatedDate = System.DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

    }
}
