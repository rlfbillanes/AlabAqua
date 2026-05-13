namespace AlabAqua.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public string? Caption { get; set; }
        public bool IsForSale { get; set; }
        public string? PriceText { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }

        public string Status { get; set; } = "Pending";
        public string? RejectionReason { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }
        public ICollection<PostMedia> Media { get; set; } = new List<PostMedia>();
        public ICollection<PostSpecies> PostSpecies { get; set; } = new List<PostSpecies>();
    }
}
