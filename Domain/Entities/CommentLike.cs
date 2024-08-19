using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class CommentLike
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Comment))]
        public string CommentId { get; set; } = null!;
        public Comment Comment { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public int Type { get; set; }
    }
}
