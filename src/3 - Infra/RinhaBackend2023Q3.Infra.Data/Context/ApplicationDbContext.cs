using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RinhaBackend2023Q3.Domain.Entities.Common;

namespace RinhaBackend2023Q3.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //{
        //    optionsBuilder.UseNpgsql(
        //        "User ID=dbhchims;Password=gTtbPj3zSxTurKcfmimQK6d-QqkOoW5i;Host=tuffi.db.elephantsql.com;Port=5432;Database=dbhchims;Pooling=true;"
        //    );
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
