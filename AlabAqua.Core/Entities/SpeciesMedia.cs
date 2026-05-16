namespace AlabAqua.Core.Entities
{
    public class SpeciesMedia
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }

        public string? MediaUrl { get; set; }
        public byte[]? MediaData { get; set; }
        public string MediaType { get; set; } = string.Empty;

        // Updated: FK must match User.Id (Guid)
        public Guid? UploadedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Species Species { get; set; } = default!;
        public User? Uploader { get; set; }
    }
}
