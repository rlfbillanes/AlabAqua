namespace AlabAqua.Core.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public string? DisplayName { get; set; }
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? AvatarUrl { get; set; }
        public string? DefaultContactEmail { get; set; }
        public string? DefaultContactPhone { get; set; }
        public string? FacebookLink { get; set; }
        public string? InstagramLink { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }
    }
}
