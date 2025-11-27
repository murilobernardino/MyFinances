namespace MyFinances.Domain.Entities;

public class CreditCardExpense
{
    public int Id { get; set; }
    
    public int CreditCardId { get; set; }
    public virtual CreditCard CreditCard { get; set; } = null!;
    
    public decimal Amount { get; set; } = 0m;
    public string Description { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    
    public int Installments { get; set; } = 1;
    public int CurrentInstallment { get; set; } = 1;
    
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    
    public int BillMonth { get; set; }
    public int BillYear { get; set; }
}