namespace AlabAqua.Core.Entities
{
    public class ArticleSpecies
    {
        public int ArticleId { get; set; }
        public int SpeciesId { get; set; }

        public Article Article { get; set; }
        public Species Species { get; set; }
    }
}
