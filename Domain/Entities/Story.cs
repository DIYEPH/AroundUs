using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class Story
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public string? Content { get; set; }
        public int StoryType { get; set; }
        public string StoryUrl { get; set; } = null!;
        public DateTime ExprirationDate { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<EmotionStory> EmotionStories { get; set; } = new HashSet<EmotionStory>();
    }
}
