namespace MyFinances.Domain.Entities;

public class CreditCard
{
    public int Id { get; set; }
    public string CardName { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    
    public int BankAccountId { get; set; }
    public virtual BankAccount BankAccount { get; set; } = null!;
    
    public int DueDay { get; set; }
    public int ClosingDay { get; set; }
    
    public virtual ICollection<Transaction> Expenses { get; set; } = new List<Transaction>();
}