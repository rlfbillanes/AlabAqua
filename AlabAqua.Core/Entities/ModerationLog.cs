namespace AlabAqua.Core.Entities
{
    public class ModerationLog
    {
        public int Id { get; set; }

        public string ContentType { get; set; } = string.Empty;
        public int ContentId { get; set; }

        // Updated: FK must match User.Id (Guid)
        public Guid? ModeratorId { get; set; }

        public string Action { get; set; } = string.Empty;
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User? Moderator { get; set; }
    }
}
