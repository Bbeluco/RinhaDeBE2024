using Microsoft.EntityFrameworkCore;

namespace Rinha;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options)
        : base(options)
    {
    }

    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<TransactionsModel> Transactions { get; set; }

    public DbSet<ResultModel> ResultBalance => Set<ResultModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientMap());

        modelBuilder.Entity<ResultModel>().HasNoKey();
        base.OnModelCreating(modelBuilder);
    }
}
