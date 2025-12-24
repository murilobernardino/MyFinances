using MyFinances.Domain.Enums;
    
    namespace MyFinances.Domain.Entities;
    
    public class Transaction
    {
        public int Id { get; set; }
    
        public TransactionType Type { get; set; }
        public TransactionNature Nature { get; set; }
    
        // Bank account relation (kept if used elsewhere)
        public int BankAccountId { get; set; }
        public virtual BankAccount? BankAccount { get; set; }
        public decimal Amount { get; set; } = 0m;
        public string Description { get; set; } = string.Empty;
    
        // General date (for card use PurchaseDate)
        public DateTime Date { get; set; } = DateTime.Now;
        
        // Payment fields
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentDate { get; set; }
    
        // Credit card specific (optional)
        public int? CreditCardId { get; set; }
        public virtual CreditCard? CreditCard { get; set; }
    
        public int? Installments { get; set; }
        public int? CurrentInstallment { get; set; }
    
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    
        // Billing info when applicable
        public int? BillMonth { get; set; }
        public int? BillYear { get; set; }
    }