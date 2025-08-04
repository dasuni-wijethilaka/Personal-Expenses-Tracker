using Microsoft.EntityFrameworkCore;
using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Data;
public class ExpenseContext : DbContext
{
    public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options) 
    { 
    }
    
    public DbSet<Expense> Expenses { get; set; }
}