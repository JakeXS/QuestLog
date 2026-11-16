using System.ComponentModel.DataAnnotations;

namespace QuestLog.Models.ViewModels
{
    public class StudioViewModel
    {
        [Required(ErrorMessage = "Studio name is required!")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Country is required!")]
        [StringLength(100, MinimumLength = 2)]
        public string Country { get; set; } = string.Empty;

    }
}
