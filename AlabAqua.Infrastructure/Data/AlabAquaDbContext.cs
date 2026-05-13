using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AlabAqua.Infrastructure.Data
{
    public class AlabAquaDbContext : DbContext
    {
        public AlabAquaDbContext(DbContextOptions<AlabAquaDbContext> options)
            : base(options)
        {
        }

        // USERS
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        // SPECIES
        public DbSet<Species> Species { get; set; }
        public DbSet<SpeciesMedia> SpeciesMedia { get; set; }

        // ARTICLES
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleSpecies> ArticleSpecies { get; set; }

        // POSTS
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostMedia> PostMedia { get; set; }
        public DbSet<PostSpecies> PostSpecies { get; set; }

        // TANKS
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<TankSpecies> TankSpecies { get; set; }

        // MODERATION
        public DbSet<ModerationLog> ModerationLogs { get; set; }
        public DbSet<AIContentCheck> AIContentChecks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
