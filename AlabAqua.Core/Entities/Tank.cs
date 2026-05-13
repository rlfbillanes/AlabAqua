namespace AlabAqua.Core.Entities
{
    public class Tank
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public string? Name { get; set; }
        public int? Size { get; set; }
        public string? Filtration { get; set; }
        public string? Lighting { get; set; }
        public string? Substrate { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public ICollection<TankSpecies> TankSpecies { get; set; } = new List<TankSpecies>();
    }
}
