using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
  {

  }

  public DbSet<Person> Persons { get; set; }
  public DbSet<Contract> Contracts { get; set; }

  protected override void OnModelCreating(ModelBuilder builder){
    builder.Entity<Person>(e =>{
      e.HasKey(p => p.Id);
      e.HasMany(e => e.Contracts)
      .WithOne()
      .HasForeignKey(e=> e.PersonId);
    });
    builder.Entity<Contract>(e =>{
      e.HasKey(c=> c.Id);
    });
  }
}