using Infrastructure.DBAgent.Postgre.Tables;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBAgent.Postgre.Context;

public class PostgreDBContext : DbContext
{
    public DbSet<EmployeePostgre> Employee { get; set; }
    public DbSet<ZaloMessageLogPostgre> ZaloMessageLog { get; set; }
    public DbSet<ZaloTokenPostgre> ZaloToken { get; set; }
    public DbSet<SMSMessageLogPostgre> SMSMessageLog { get; set; }

    //Override constructor DbContext
    public PostgreDBContext(DbContextOptions<PostgreDBContext> options)
        : base(options) { }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.CurrentValues["CreatedAt"] = DateTimeOffset.UtcNow;
                entry.CurrentValues["UpdatedAt"] = DateTimeOffset.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.CurrentValues["UpdatedAt"] = DateTimeOffset.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    //Override Create Model in DB
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Setup soft delete
        modelBuilder.Entity<EmployeePostgre>(entity =>
        {
            entity.HasQueryFilter(u => !u.DeletedAt.HasValue);
        });

        modelBuilder.Entity<ZaloMessageLogPostgre>(entity =>
        {
            entity.HasQueryFilter(u => !u.DeletedAt.HasValue);
        });

        modelBuilder.Entity<ZaloTokenPostgre>(entity =>
        {
            entity.HasQueryFilter(u => !u.DeletedAt.HasValue);
        });

        modelBuilder.Entity<SMSMessageLogPostgre>(entity =>
        {
            entity.HasQueryFilter(u => !u.DeletedAt.HasValue);
        });
    }
}
