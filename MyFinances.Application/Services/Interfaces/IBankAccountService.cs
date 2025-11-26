using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;

namespace MyFinances.Application.Services.Interfaces;

public interface IBankAccountService
{
    Task<IEnumerable<BankAccountResponse>> GetAllAsync();
    Task<BankAccountResponse?> GetByIdAsync(int id);
    Task<BankAccountResponse> CreateAsync(BankAccountRequest request);
    Task<bool> UpdateAsync(int id, BankAccountRequest request);
    Task<bool> DeleteAsync(int id);
}