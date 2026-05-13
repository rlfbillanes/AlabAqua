namespace AlabAqua.Core.Entities
{
    public class PostSpecies
    {
        public int PostId { get; set; }
        public int SpeciesId { get; set; }

        public Post Post { get; set; }
        public Species Species { get; set; }
    }
}
