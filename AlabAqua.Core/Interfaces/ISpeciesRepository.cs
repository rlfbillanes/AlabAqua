using AlabAqua.Core.Entities;

namespace AlabAqua.Core.Interfaces
{
    public interface ISpeciesRepository : IGenericRepository<Species>
    {
        Task<Species?> GetByScientificNameAsync(string scientificName);
    }
}
