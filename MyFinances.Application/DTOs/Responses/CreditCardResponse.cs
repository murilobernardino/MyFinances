namespace MyFinances.Application.DTOs.Responses
{
    public class CreditCardResponse
    {
        public int Id { get; set; }

        public string CardName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;

        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; } = string.Empty;

        public int ClosingDay { get; set; }
        public int DueDay { get; set; }
    }
}