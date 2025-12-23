using Microsoft.EntityFrameworkCore;
using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;
using MyFinances.Application.Services.Interfaces;
using MyFinances.Data.Context;
using MyFinances.Domain.Entities;

namespace MyFinances.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly MyFinancesDbContext _context;
    
    public CategoryService(MyFinancesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryResponse>> GetAllASync()
    {
        return await _context.Categories
            .Select(x => new CategoryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ParentCategoryId = x.ParentCategoryId,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<CategoryResponse?> GetByIdAsync(int id)
    {
        var entity = await _context.Categories
            .Include(x => x.ParentCategory)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null) return null;

        return new CategoryResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ParentCategoryId = entity.ParentCategoryId,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
    }

    public async Task<CategoryResponse> CreateAsync(CategoryRequest request)
    {
        var entity = new Category
        {
            Name = request.Name,
            Description = request.Description,
            ParentCategoryId = request.ParentCategoryId,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
        
        _context.Categories.Add(entity);
        await _context.SaveChangesAsync();

        return new CategoryResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ParentCategoryId = entity.ParentCategoryId,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, CategoryRequest request)
    {
        var entity = await _context.Categories.FindAsync(id);
        if (entity == null) return false;

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.ParentCategoryId = request.ParentCategoryId;
        entity.IsActive = request.IsActive;
            
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Categories.FindAsync(id);
        if (entity == null) return false;
        
        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}