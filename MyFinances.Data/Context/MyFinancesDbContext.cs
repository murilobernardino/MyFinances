using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.Entities;

namespace MyFinances.Data.Context;

public class MyFinancesDbContext : IdentityDbContext
{
    public MyFinancesDbContext(DbContextOptions<MyFinancesDbContext> options) : base(options) { }
    
    public DbSet<BankAccount> BankAccounts { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;
    public DbSet<CreditCard> CreditCards { get; set; } = null!;
    public DbSet<CreditCardExpense> CreditCardExpenses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}