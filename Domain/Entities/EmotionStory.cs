using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class EmotionStory
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Story))]
        public string StoryId { get; set; } = null!;
        public Story Story { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public int EmotionType { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
