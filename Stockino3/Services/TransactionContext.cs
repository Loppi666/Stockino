using Microsoft.EntityFrameworkCore;

namespace Stockino3.Services;

public class TransactionContext(DbContextOptions<TransactionContext> options) : DbContext(options)
{
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransactionEntity>()
                    .HasOne(t => t.Product)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(t => t.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}
