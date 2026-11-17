using System.ComponentModel.DataAnnotations;

namespace QuestLog.Models.ViewModels
{
    public class MilestoneViewModel
    {
        [Required(ErrorMessage = "Milestone Title is required!")]
        [StringLength(120, MinimumLength = 2)]
        public string MilestoneTitle { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime AchievedDate { get; set; } = DateTime.Today;
        [Required]
        [Range(0.1, 5000, ErrorMessage = "Hours must be between 0.1 and 5000")]
        public decimal HoursLogged { get; set; }
        [Required]
        public int VideoGameId { get; set; }
    }
}
