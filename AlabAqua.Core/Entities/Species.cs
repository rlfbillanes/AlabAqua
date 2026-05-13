namespace AlabAqua.Core.Entities
{
    public class Species
    {
        public int Id { get; set; }
        public string ScientificName { get; set; } = string.Empty;
        public string? CommonName { get; set; }
        public string WaterType { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int? MinTankSize { get; set; }
        public string? Diet { get; set; }
        public string? Temperament { get; set; }
        public string? CareLevel { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<SpeciesMedia> Media { get; set; } = new List<SpeciesMedia>();
        public ICollection<ArticleSpecies> ArticleSpecies { get; set; } = new List<ArticleSpecies>();
        public ICollection<PostSpecies> PostSpecies { get; set; } = new List<PostSpecies>();
        public ICollection<TankSpecies> TankSpecies { get; set; } = new List<TankSpecies>();
    }
}
