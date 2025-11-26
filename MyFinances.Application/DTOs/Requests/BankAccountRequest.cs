namespace MyFinances.Application.DTOs.Requests;

public class BankAccountRequest
{
    public string Name { get; set; } = string.Empty;
    public string Bank { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public decimal InitialBalance { get; set; }
}
