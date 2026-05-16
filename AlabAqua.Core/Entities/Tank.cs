namespace AlabAqua.Core.Entities
{
    public class Tank
    {
        public int Id { get; set; }

        // FK must match User.Id (Guid)
        public Guid UserId { get; set; }

        public string? Name { get; set; }
        public int? Size { get; set; }
        public string? Filtration { get; set; }
        public string? Lighting { get; set; }
        public string? Substrate { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User User { get; set; } = default!;
        public ICollection<TankSpecies> TankSpecies { get; set; } = new List<TankSpecies>();
    }
}
