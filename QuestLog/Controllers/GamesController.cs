using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestLog.Models.Data;
using QuestLog.Models.ViewModels;

namespace QuestLog.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public GamesController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var games = await _dbContext.VideoGames.Include(g=> g.Studio).ToListAsync();
            return View(games);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new GameViewModel()
            {
                Studios = await GetStudiosSelectedListAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Studios = await GetStudiosSelectedListAsync();
                return View(model);
            }

            var game = new VideoGame
            {
                Title = model.Title,
                Platform = model.Platform,
                ReleaseYear = model.ReleaseYear,
                IsComplete = model.IsComplete,
                StudioId = model.StudioId,
            };
            _dbContext.VideoGames.Add(game);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var game = await _dbContext.VideoGames.Include(g => g.Studio)
                .Include(g => g.Milestones)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _dbContext.VideoGames.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            var model = new GameViewModel
            {
                Id = game.Id,
                Title = game.Title,
                Platform = game.Platform,
                ReleaseYear = game.ReleaseYear,
                IsComplete = game.IsComplete,
                StudioId = game.StudioId,
                Studios = await GetStudiosSelectedListAsync()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Studios = await GetStudiosSelectedListAsync();
                return View(model);
            }
            var game = await _dbContext.VideoGames.FindAsync(model.Id);
            if(game  == null)
            {
                return NotFound();
            }
            game.Title = model.Title;
            game.Platform = model.Platform;
            game.ReleaseYear = model.ReleaseYear;
            game.IsComplete = model.IsComplete;
            game.StudioId = model.StudioId;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _dbContext.VideoGames.Include(g=>
            g.Studio).FirstOrDefaultAsync(g=>g.Id == id);
            if(game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> Deleted(int id)
        {
            var game = await _dbContext.VideoGames.FindAsync(id);
            if(game != null)
            {
                _dbContext.VideoGames.Remove(game);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>> GetStudiosSelectedListAsync()
        {
            return await _dbContext.Studios
                .Select(s => new  SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();
        }
    }
}
