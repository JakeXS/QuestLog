using Microsoft.AspNetCore.Mvc;
using QuestLog.Models.Data;
using QuestLog.Models.ViewModels;

namespace QuestLog.Controllers
{
    public class MilestonesController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public MilestonesController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int gameId)
        {
            var game = await _dbContext.VideoGames.FindAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }
            ViewBag.GameTitle = game.Title;
            return View(new MilestoneViewModel { VideoGameId = gameId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MilestoneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var milestone = new PlayMilestone
            {
                MilestoneTitle = model.MilestoneTitle,
                AchievedDate = model.AchievedDate,
                HoursLogged = model.HoursLogged,
                VideoGameId = model.VideoGameId,
            };
            _dbContext.PlayMilestones.Add(milestone);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Details", "Games", new {id = model.VideoGameId});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var milestone = await _dbContext.PlayMilestones.FindAsync(id);
            if (milestone == null)
            {
                return NotFound();
            }

            int gameId = milestone.VideoGameId;
            _dbContext.PlayMilestones.Remove(milestone);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Details", "Games", new { id = gameId });
        }
    }
}
