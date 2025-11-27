namespace MyFinances.Application.DTOs.Responses
{
    public class CreditCardExpenseResponse
    {
        public int Id { get; set; }

        public int CreditCardId { get; set; }
        public string CreditCardName { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }

        public int Installments { get; set; }
        public int CurrentInstallment { get; set; }
        
        public int CategoryId { get; set; }

        public int BillMonth { get; set; }
        public int BillYear { get; set; }

    }
}