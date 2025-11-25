namespace MyFinances.Domain.Entities;

public class BankAccount
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Bank { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public decimal InitialBalance { get; set; } = 0m;
    
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public virtual ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();
}