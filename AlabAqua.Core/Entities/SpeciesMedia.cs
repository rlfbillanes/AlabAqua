namespace AlabAqua.Core.Entities
{
    public class SpeciesMedia
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }

        public string? MediaUrl { get; set; }
        public byte[]? MediaData { get; set; }
        public string MediaType { get; set; } = string.Empty;

        public string? UploadedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public Species Species { get; set; }
        public User? Uploader { get; set; }
    }
}
