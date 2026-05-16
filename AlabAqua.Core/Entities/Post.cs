namespace AlabAqua.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }

        // FK must match User.Id (Guid)
        public Guid UserId { get; set; }

        public string? Caption { get; set; }
        public bool IsForSale { get; set; }
        public string? PriceText { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }

        public string Status { get; set; } = "Pending";
        public string? RejectionReason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User User { get; set; } = default!;
        public ICollection<PostMedia> Media { get; set; } = new List<PostMedia>();
        public ICollection<PostSpecies> PostSpecies { get; set; } = new List<PostSpecies>();
    }
}
