namespace MyFinances.Application.DTOs.Requests
{
    public class CreditCardExpenseRequest
    {
        public int CreditCardId { get; set; }
        
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public int Installments { get; set; } = 1;
        public int CurrentInstallment { get; set; } = 1;
        
        public int CategoryId { get; set; }

        public int BillMonth { get; set; }
        public int BillYear { get; set; }
    }
}