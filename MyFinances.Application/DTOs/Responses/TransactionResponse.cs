using MyFinances.Domain.Enums;
    
    namespace MyFinances.Application.DTOs.Responses;
    
    public class TransactionResponse
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public TransactionNature Nature { get; set; }
    
        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; } = "";
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    
        public int? CreditCardId { get; set; }
        public int? Installments { get; set; }
        public int? CurrentInstallment { get; set; }
    
        public int? CategoryId { get; set; }
        public int? BillMonth { get; set; }
        public int? BillYear { get; set; }
    }