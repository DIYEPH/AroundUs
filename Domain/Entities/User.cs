using Microsoft.AspNetCore.Identity;

namespace AROUNDUS.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public bool? IsDiscoverable { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        public ICollection<Message> SendMessage { get; set; } = new HashSet<Message>();
        public ICollection<Message> ReceiveMessage { get; set; } = new HashSet<Message>();
        public ICollection<GroupMember> GroupMembers { get; set; } = new HashSet<GroupMember>();
        public ICollection<SpecialRelationship> SpecialRelationshipsAsUser { get; set; } = new HashSet<SpecialRelationship>();
        public ICollection<SpecialRelationship> SpecialRelationshipsAsRelateUser { get; set; } = new HashSet<SpecialRelationship>();
        public ICollection<Follow> Followers { get; set; } = new HashSet<Follow>();
        public ICollection<Follow> Followeds { get; set; } = new HashSet<Follow>();
        public ICollection<EmotionStory> EmotionStories { get; set; } = new HashSet<EmotionStory>();
        public ICollection<CommentLike> CommentLikes { get; set; } = new HashSet<CommentLike>();

    }
}
