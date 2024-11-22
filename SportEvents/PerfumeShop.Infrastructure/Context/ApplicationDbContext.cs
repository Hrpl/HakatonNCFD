using Microsoft.EntityFrameworkCore;
using PerfumeShop.Domain.Entities;
using SportEvents.Domain.Entities;

namespace PerfumeShop.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<SportEvent> SportEvents { get; set; }
    public DbSet<Composition> Compositions {  get; set; }
    public DbSet<TypeSportEvent> TypeSports { get; set; }
    public DbSet<FavouritesEvent> FavouritesEvents { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
