namespace AlabAqua.Core.Entities
{
    public class TankSpecies
    {
        public int TankId { get; set; }
        public int SpeciesId { get; set; }

        public Tank Tank { get; set; }
        public Species Species { get; set; }
    }
}
