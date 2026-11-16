using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestLog.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace QuestLog.Models.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        [StringLength(150, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Platform is required!")]
        [StringLength(30, MinimumLength = 2)]
        public string Platform { get; set; } = string.Empty;
        [Range(1960, 2026)]
        public int ReleaseYear { get; set; }
        public bool IsComplete { get; set; }
        [Required, Display(Name = "Studio")]
        public int StudioId { get; set; }
        public IEnumerable<SelectListItem> Studios { get; set; } = new List<SelectListItem>();
    }
}
