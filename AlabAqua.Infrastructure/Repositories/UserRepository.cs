using AlabAqua.Core.Entities;
using AlabAqua.Core.Interfaces;
using AlabAqua.Infrastructure.Data;

namespace AlabAqua.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AlabAquaDbContext context) : base(context)
        {
        }
    }
}
