using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestLog.Models.Data;
using QuestLog.Models.ViewModels;

namespace QuestLog.Controllers
{
    public class StudiosController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public StudiosController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var studios = await _dbContext.Studios.ToListAsync();
            return View(studios);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new StudioViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var studio = new Studio
            {
                Name = model.Name,
                Country = model.Country
            };
            _dbContext.Studios.Add(studio);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");  

        }
    }
}
