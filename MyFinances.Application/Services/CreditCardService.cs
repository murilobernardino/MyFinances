using Microsoft.EntityFrameworkCore;
using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;
using MyFinances.Application.Services.Interfaces;
using MyFinances.Data.Context;
using MyFinances.Domain.Entities;

public class CreditCardService : ICreditCardService
{
    private readonly MyFinancesDbContext _context;

    public CreditCardService(MyFinancesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CreditCardResponse>> GetAllAsync()
    {
        return await _context.CreditCards
            .Select(c => new CreditCardResponse
            {
                Id = c.Id,
                CardName = c.CardName,
                CardNumber = c.CardNumber,
                BankAccountId = c.BankAccountId,
                BankAccountName = c.BankAccount.Name,
                ClosingDay = c.ClosingDay,
                DueDay = c.DueDay
            })
            .ToListAsync();
    }
    
    public async Task<CreditCardResponse?> GetByIdAsync(int id)
    {
        var c = await _context.CreditCards
            .Include(x => x.BankAccount)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if(c == null) return null;
        
        return new CreditCardResponse
        {
            Id = c.Id,
            CardName = c.CardName,
            CardNumber = c.CardNumber,
            BankAccountId = c.BankAccountId,
            BankAccountName = c.BankAccount.Name,
            ClosingDay = c.ClosingDay,
            DueDay = c.DueDay
        };
    }

    public async Task<CreditCardResponse> CreateAsync(CreditCardRequest request)
    {
        var c = new CreditCard
        {
            CardName = request.CardName,
            CardNumber = request.CardNumber,
            BankAccountId = request.BankAccountId,
            ClosingDay = request.ClosingDay,
            DueDay = request.DueDay
        };
        
        _context.CreditCards.Add(c);
        await _context.SaveChangesAsync();
        
        await _context.Entry(c).Reference(x => x.BankAccount).LoadAsync();

        return new CreditCardResponse
        {
            Id = c.Id,
            CardName = c.CardName,
            CardNumber = c.CardNumber,
            BankAccountId = c.BankAccountId,
            BankAccountName = c.BankAccount.Name,
            ClosingDay = c.ClosingDay,
            DueDay = c.DueDay
        };
    }
    
    public async Task<bool> UpdateAsync(int id, CreditCardRequest request)
    {
        var entity = await _context.CreditCards.FindAsync(id);
        if (entity == null) return false;
        
        entity.CardName = request.CardName;
        entity.CardNumber = request.CardNumber;
        entity.BankAccountId = request.BankAccountId;
        entity.ClosingDay = request.ClosingDay;
        entity.DueDay = request.DueDay;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.CreditCards.FindAsync(id);
        if (entity == null) return false;
        
        _context.CreditCards.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}