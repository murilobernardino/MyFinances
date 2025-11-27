namespace MyFinances.Domain.Entities;

public class AccountPayable
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public decimal Amount { get; set; } = 0m;
    public DateTime DueDate { get; set; } = DateTime.Now;
    
    public bool IsPaid { get; set; }
    public DateTime? PaidDate { get; set; }
    
    public int? TransactionId { get; set; }
    public virtual Transaction? Transaction { get; set; }
    
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    
    public bool IsRecurring { get; set; }
    public RecurrenceType? RecurrenceType { get; set; }
}

public enum RecurrenceType
{
    Monthly,
    Weekly,
    Yearly
}
