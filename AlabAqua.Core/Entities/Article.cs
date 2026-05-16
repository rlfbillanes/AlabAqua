namespace AlabAqua.Core.Entities
{
    public class Article
    {
        public int Id { get; set; }

        // FK must match User.Id (Guid)
        public Guid AuthorId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";
        public string? RejectionReason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User Author { get; set; } = default!;
        public ICollection<ArticleSpecies> ArticleSpecies { get; set; } = new List<ArticleSpecies>();
    }
}
