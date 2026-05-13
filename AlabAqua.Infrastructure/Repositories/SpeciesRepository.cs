using AlabAqua.Core.Entities;
using AlabAqua.Core.Interfaces;
using AlabAqua.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlabAqua.Infrastructure.Repositories
{
    public class SpeciesRepository : GenericRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(AlabAquaDbContext context) : base(context)
        {
        }

        public async Task<Species?> GetByScientificNameAsync(string scientificName)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.ScientificName == scientificName);
        }
    }
}
