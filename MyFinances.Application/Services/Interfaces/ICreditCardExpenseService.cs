using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;

namespace MyFinances.Application.Services.Interfaces;

public interface ICreditCardExpenseService
{
    Task<IEnumerable<CreditCardExpenseResponse>> GetAllAsync();
    Task<CreditCardExpenseResponse?> GetByIdAsync(int id);
    Task<CreditCardExpenseResponse> CreateAsync(CreditCardExpenseRequest request);
    Task<bool> UpdateAsync(int id, CreditCardExpenseRequest request);
    Task<bool> DeleteAsync(int id);
}