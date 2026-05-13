namespace AlabAqua.Core.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string AuthorId { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";
        public string? RejectionReason { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User Author { get; set; }
        public ICollection<ArticleSpecies> ArticleSpecies { get; set; } = new List<ArticleSpecies>();
    }
}
