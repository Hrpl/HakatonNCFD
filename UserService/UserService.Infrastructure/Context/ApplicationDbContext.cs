using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public DbSet<Jwt> JwtTokens { get; set; }
    public DbSet<EmailEvent> EmailEvents { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}

