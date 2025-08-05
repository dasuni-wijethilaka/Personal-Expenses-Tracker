using Microsoft.EntityFrameworkCore;
using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Data;
public class ExpenseContext : DbContext
{
    public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options) 
    { 
    }
    
    public DbSet<Expense> Expenses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2); // 18 total digits, 2 decimal places
                
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsRequired();
                
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsRequired();
        });
        
        base.OnModelCreating(modelBuilder);
    }
}