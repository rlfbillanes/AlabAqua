namespace AlabAqua.Core.Entities
{
    public class PostMedia
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        public string? MediaUrl { get; set; }
        public byte[]? MediaData { get; set; }
        public string MediaType { get; set; } = string.Empty;

        public string? ThumbnailUrl { get; set; }
        public int SortOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        public Post Post { get; set; }
    }
}
