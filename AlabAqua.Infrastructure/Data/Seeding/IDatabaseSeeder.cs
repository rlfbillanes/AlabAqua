using System.Threading.Tasks;

namespace AlabAqua.Infrastructure.Data.Seeding
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
