using Microsoft.EntityFrameworkCore;
using rpg_character.Models;

namespace rpg_character.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    // DbSet properties expose tables for querying
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Skills> Skills => Set<Skills>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Character -> Skills (1 to many)
        modelBuilder.Entity<Character>()
            .HasMany(c => c.Skills)
            .WithOne(s => s.Character)
            .HasForeignKey(s => s.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        // Enum Gender config (optional but better explicit)
        modelBuilder.Entity<Character>()
            .Property(c => c.Gender)
            .HasConversion<string>();
    }
}