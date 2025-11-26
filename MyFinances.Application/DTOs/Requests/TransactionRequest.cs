using MyFinances.Domain.Entities;

namespace MyFinances.Application.DTOs.Requests;

public class TransactionRequest
{
    public int BankAccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public string Description { get; set; } = string.Empty;
}
