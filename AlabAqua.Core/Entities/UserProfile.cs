public class UserProfile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    // Required
    public string DisplayName { get; set; } = default!;
    public string AvatarUrl { get; set; } = "/images/default-avatar.png";
    public string Location { get; set; } = default!;

    // Optional
    public string? Bio { get; set; }
    public string? ExperienceLevel { get; set; }
    public string? FavoriteSpecies { get; set; }
    public int? AquariumCount { get; set; }

    public DateTime JoinedDate { get; set; } = DateTime.UtcNow;

    // Navigation
    public User User { get; set; } = default!;
}
