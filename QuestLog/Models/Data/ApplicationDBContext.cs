using Microsoft.EntityFrameworkCore;

namespace QuestLog.Models.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Studio> Studios { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<PlayMilestone> PlayMilestones { get; set; }
    }
}
