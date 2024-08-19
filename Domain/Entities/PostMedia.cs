using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class PostMedia
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Post))]
        public string PostId { get; set; } = null!;
        public Post Post { get; set; } = null!;
        public int MediaType { get; set; }
        public string MediaUrl { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
