using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;

namespace MyFinances.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponse>> GetAllASync();
    Task<CategoryResponse?> GetByIdAsync(int id);
    Task<CategoryResponse> CreatedAsync(CategoryRequest request);
    Task<bool> UpdateAsync(int id, CategoryRequest request);
    Task<bool> DeleteAsync(int id);
}