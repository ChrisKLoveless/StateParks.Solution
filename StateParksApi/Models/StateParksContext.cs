using Microsoft.EntityFrameworkCore;

namespace StateParks.Models
{
  public class StateParksContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }
    public DbSet<State> State { get; set; }

    public StateParksContext(DbContextOptions<StateParksContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<State>()
      .HasData(
        new State { StateId = 1, Name = "Oregon", ParkId = 1 },
        new State { StateId = 2, Name = "Washington", ParkId = 2},
        new State { StateId = 3, Name = "California", ParkId = 3}
      );
      builder.Entity<Park>()
      .HasData(
        new Park { ParkId = 1, Name = "Crater Lake", StateId = 1 },
        new Park { ParkId = 2, Name = "Lewis and Clark", StateId = 2 },
        new Park { ParkId = 3, Name = "Golden Gate", StateId = 3 }
      );
    }
  }
}