using System.ComponentModel.DataAnnotations;

namespace QuestLog.Models.Data
{
    public class Studio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
        public ICollection<VideoGame> Games { get; set; } = new List<VideoGame>();


    }
}
