namespace MyFinances.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public int BankAccountId { get; set; }
    public virtual BankAccount BankAccount { get; set; } = null!;
    
    public decimal Amount { get; set; } = 0m;
    public DateTime Date { get; set; } = DateTime.Now;
    
    public TransactionType Type { get; set; }
    public string Description { get; set; } = string.Empty;
}

public enum TransactionType
{
    Income = 1,
    Expense = 2
}