namespace AlabAqua.Core.Entities
{
    public class ModerationLog
    {
        public int Id { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public int ContentId { get; set; }

        public string? ModeratorId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public User? Moderator { get; set; }
    }
}
