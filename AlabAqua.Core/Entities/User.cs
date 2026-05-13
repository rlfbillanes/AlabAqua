namespace AlabAqua.Core.Entities
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Member";
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public UserProfile? Profile { get; set; }
        public ICollection<SpeciesMedia> UploadedSpeciesMedia { get; set; } = new List<SpeciesMedia>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<ModerationLog> ModerationLogs { get; set; } = new List<ModerationLog>();
    }
}
