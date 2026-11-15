using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestLog.Models.Data
{
    public class PlayMilestone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string MilestoneTitle { get; set; } = string.Empty;
        [Required]
        public DateTime AchievedDate { get; set; } = DateTime.Today;
        [Required]
        [Range(0.1, 5000)]
        [Column(TypeName = "decimal(6,1)")]
        public decimal HoursLogged {  get; set; }

        [Required]
        public int VideoGameId { get; set; }
        [ForeignKey(nameof(VideoGameId))]
        public VideoGame VideoGame { get; set; } = null!;

    }
}
