using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Post))]
        public string PostId { get; set; } = null!;
        public Post Post { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        [ForeignKey(nameof(ParentComment))]
        public string ParentCommentId { get; set; } = null!;
        public Comment ParentComment { get; set; } = null!;
        public ICollection<Comment> ChildComments { get; set; } = new HashSet<Comment>();
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; } = new HashSet<CommentLike>();

    }
}
