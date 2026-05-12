using AlabAqua.Infrastructure.Data;
using AlabAqua.Infrastructure.Data.Seeding;
using AlabAqua.Core.Interfaces;
using AlabAqua.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// Repository Registrations
// --------------------------------------------------
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();

// --------------------------------------------------
// DbContext
// --------------------------------------------------
builder.Services.AddDbContext<AlabAquaDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// --------------------------------------------------
// Seeder
// --------------------------------------------------
builder.Services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

// --------------------------------------------------
// MVC
// --------------------------------------------------
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --------------------------------------------------
// Run Seeder
// --------------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
    await seeder.SeedAsync();
}

// --------------------------------------------------
// Middleware Pipeline
// --------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// --------------------------------------------------
// ROUTING — AREA ROUTE MUST COME FIRST
// --------------------------------------------------
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

// --------------------------------------------------
// DEFAULT ROUTE
// --------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
