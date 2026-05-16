using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlabAqua.Infrastructure.Data.Seeding
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly AlabAquaDbContext _context;

        public DatabaseSeeder(AlabAquaDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();

            await SeedAdminUserAsync();
            await SeedSampleSpeciesAsync();
        }

        private async Task SeedAdminUserAsync()
        {
            // If ANY user exists, skip
            if (await _context.Users.AnyAsync())
                return;

            // Create admin user
            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@alabaqua.com",
                PasswordHash = PasswordHasher.Hash("Admin123!"),
                CreatedAt = DateTime.UtcNow
            };

            // Create admin profile
            var adminProfile = new UserProfile
            {
                Id = Guid.NewGuid(),
                UserId = adminUser.Id,
                DisplayName = "Administrator",
                Location = "Philippines",
                AvatarUrl = "/images/default-avatar.png",
                JoinedDate = DateTime.UtcNow
            };

            _context.Users.Add(adminUser);
            _context.UserProfiles.Add(adminProfile);

            await _context.SaveChangesAsync();
        }

        private async Task SeedSampleSpeciesAsync()
        {
            if (await _context.Species.AnyAsync())
                return;

            var speciesList = new List<Species>
            {
                new Species
                {
                    ScientificName = "Betta splendens",
                    CommonName = "Betta Fish",
                    WaterType = "Freshwater",
                    Difficulty = "Easy",
                    MinTankSize = 5,
                    Diet = "Carnivore",
                    Temperament = "Semi-aggressive",
                    CareLevel = "Easy",
                    Description = "Known for its vibrant colors and flowing fins.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Species
                {
                    ScientificName = "Paracheirodon innesi",
                    CommonName = "Neon Tetra",
                    WaterType = "Freshwater",
                    Difficulty = "Easy",
                    MinTankSize = 10,
                    Diet = "Omnivore",
                    Temperament = "Peaceful",
                    CareLevel = "Easy",
                    Description = "A small schooling fish with bright neon blue and red coloration.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Species
                {
                    ScientificName = "Poecilia reticulata",
                    CommonName = "Guppy",
                    WaterType = "Freshwater",
                    Difficulty = "Easy",
                    MinTankSize = 10,
                    Diet = "Omnivore",
                    Temperament = "Peaceful",
                    CareLevel = "Easy",
                    Description = "A hardy livebearer species known for its colorful tail patterns.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Species
                {
                    ScientificName = "Astronotus ocellatus",
                    CommonName = "Oscar",
                    WaterType = "Freshwater",
                    Difficulty = "Intermediate",
                    MinTankSize = 55,
                    Diet = "Carnivore",
                    Temperament = "Aggressive",
                    CareLevel = "Intermediate",
                    Description = "A large cichlid species known for its intelligence and personality.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Species
                {
                    ScientificName = "Amphiprion ocellaris",
                    CommonName = "Clownfish",
                    WaterType = "Saltwater",
                    Difficulty = "Intermediate",
                    MinTankSize = 20,
                    Diet = "Omnivore",
                    Temperament = "Peaceful",
                    CareLevel = "Intermediate",
                    Description = "A saltwater species famous for its symbiotic relationship with anemones.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            _context.Species.AddRange(speciesList);
            await _context.SaveChangesAsync();
        }
    }
}
