using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class Like
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Type { get; set; }
        public DateTime CreateAt { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        [ForeignKey(nameof(Post))]
        public string PostId { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
