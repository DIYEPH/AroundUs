using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class Follow
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(Follower))]
        public string FollowerId { get; set; } = null!;
        public User Follower { get; set; } = null!;

        [ForeignKey(nameof(Followed))]
        public string FollowedId { get; set; } = null!;
        public User Followed { get; set; } = null!;

        public bool IsFriend { get; set; }
        public DateTime CreateAt { get; set; }
    }
}