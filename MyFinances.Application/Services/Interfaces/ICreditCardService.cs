using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;

namespace MyFinances.Application.Services.Interfaces;

public interface ICreditCardService
{
    Task<IEnumerable<CreditCardResponse>> GetAllAsync();
    Task<CreditCardResponse?> GetByIdAsync(int id);
    Task<CreditCardResponse> CreateAsync(CreditCardRequest request);
    Task<bool> UpdateAsync(int id, CreditCardRequest request);
    Task<bool> DeleteAsync(int id);
}