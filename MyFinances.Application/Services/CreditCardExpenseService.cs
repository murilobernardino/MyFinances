using Microsoft.EntityFrameworkCore;
using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;
using MyFinances.Application.Services.Interfaces;
using MyFinances.Data.Context;
using MyFinances.Domain.Entities;

namespace MyFinances.Application.Services;

public class CreditCardExpenseService : ICreditCardExpenseService
{
    private readonly MyFinancesDbContext _context;
    
    public CreditCardExpenseService(MyFinancesDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<CreditCardExpenseResponse>> GetAllAsync()
    {
        return await _context.CreditCardExpenses
            .Select(e => new CreditCardExpenseResponse
            {
                Id = e.Id,
                CreditCardId = e.CreditCardId,
                CreditCardName = e.CreditCard.CardName,
                Amount = e.Amount,
                PurchaseDate = e.PurchaseDate,
                Description = e.Description,
                Installments = e.Installments,
                CurrentInstallment = e.CurrentInstallment
            })
            .ToListAsync();
    }

    public async Task<CreditCardExpenseResponse?> GetByIdAsync(int id)
    {
        var e = await _context.CreditCardExpenses
            .Include(x => x.CreditCard)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (e == null) return null;

        return new CreditCardExpenseResponse
        {
            Id = e.Id,
            CreditCardId = e.CreditCardId,
            CreditCardName = e.CreditCard.CardName,
            Amount = e.Amount,
            PurchaseDate = e.PurchaseDate,
            Description = e.Description,
            Installments = e.Installments,
            CurrentInstallment = e.CurrentInstallment
        };
    }

    public async Task<CreditCardExpenseResponse> CreateAsync(CreditCardExpenseRequest request)
    {
        var e = new CreditCardExpense
        {
            CreditCardId = request.CreditCardId,
            Amount = request.Amount,
            PurchaseDate = request.PurchaseDate,
            Description = request.Description,
            Installments = request.Installments,
            CurrentInstallment = request.CurrentInstallment
        };
        
        _context.CreditCardExpenses.Add(e);
        await _context.SaveChangesAsync();

        return new CreditCardExpenseResponse
        {
            Id = e.Id,
            CreditCardId = e.CreditCardId,
            CreditCardName = _context.CreditCards.Find(e.CreditCardId)!.CardName,
            Amount = e.Amount,
            PurchaseDate = e.PurchaseDate,
            Description = e.Description,
            Installments = e.Installments,
            CurrentInstallment = e.CurrentInstallment
        };
    }

    public async Task<bool> UpdateAsync(int id, CreditCardExpenseRequest request)
    {
        var entity = await _context.CreditCardExpenses.FindAsync(id);
        if (entity == null) return false;
        
        entity.CreditCardId = request.CreditCardId;
        entity.Amount = request.Amount;
        entity.PurchaseDate = request.PurchaseDate;
        entity.Description = request.Description;
        entity.Installments = request.Installments;
        entity.CurrentInstallment = request.CurrentInstallment;
        
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.CreditCardExpenses.FindAsync(id);
        if (entity == null) return false;
        
        _context.CreditCardExpenses.Remove(entity);
        await _context.SaveChangesAsync();
        
        return true;
    }
}