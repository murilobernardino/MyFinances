using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;

namespace MyFinances.Application.Services.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<TransactionResponse>> GetAllAsync();
    Task<TransactionResponse?> GetByIdAsync(int id);
    Task<TransactionResponse> CreateAsync(TransactionRequest request);
    Task<bool> UpdateAsync(int id, TransactionRequest request);
    Task<bool> DeleteAsync(int id);
}