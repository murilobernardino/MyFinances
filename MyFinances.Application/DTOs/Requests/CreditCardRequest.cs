using MyFinances.Domain.Entities;

namespace MyFinances.Application.DTOs.Requests;

public class CreditCardRequest
{
    public string CardName { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public int BankAccountId { get; set; }
    public int ClosingDay { get; set; }
    public int DueDay { get; set; }
}
