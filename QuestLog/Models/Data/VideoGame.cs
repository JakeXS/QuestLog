using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestLog.Models.Data
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Platform { get; set; } = string.Empty;
        [Range(1960, 2026)]
        public int ReleaseYear { get; set; }
        public bool IsComplete { get; set; }
        [Required]
        public int StudioId { get; set; }

        [ForeignKey(nameof(StudioId))]
        public Studio Studio { get; set; } = null!;

        public ICollection<PlayMilestone> Milestones { get; set; } = new List<PlayMilestone>();

    }
}
