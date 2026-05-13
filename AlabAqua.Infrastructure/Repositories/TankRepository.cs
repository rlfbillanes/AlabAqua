using AlabAqua.Core.Entities;
using AlabAqua.Core.Interfaces;
using AlabAqua.Infrastructure.Data;

namespace AlabAqua.Infrastructure.Repositories
{
    public class TankRepository : GenericRepository<Tank>, ITankRepository
    {
        public TankRepository(AlabAquaDbContext context) : base(context)
        {
        }
    }
}
