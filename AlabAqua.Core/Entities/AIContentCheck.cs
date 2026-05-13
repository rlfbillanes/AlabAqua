namespace AlabAqua.Core.Entities
{
    public class AIContentCheck
    {
        public int Id { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public int ContentId { get; set; }

        public bool? IsAquaticRelated { get; set; }
        public decimal? ConfidenceScore { get; set; }
        public string? RawResultJson { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
