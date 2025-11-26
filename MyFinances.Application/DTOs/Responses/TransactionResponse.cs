using MyFinances.Domain.Entities;

namespace MyFinances.Application.DTOs.Responses;

public class TransactionResponse
{
    public int Id { get; set; }
    public int BankAccountId { get; set; }
    public string BankAccountName { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public string Description { get; set; } = string.Empty;
    
}
