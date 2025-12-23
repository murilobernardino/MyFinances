using Microsoft.EntityFrameworkCore;
using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.DTOs.Responses;
using MyFinances.Application.Services.Interfaces;
using MyFinances.Data.Context;
using MyFinances.Domain.Entities;

namespace MyFinances.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly MyFinancesDbContext _context;
    
    public TransactionService(MyFinancesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TransactionResponse>> GetAllAsync()
    {
        return await _context.Transactions
            .Select(t => new TransactionResponse
            {
                Id = t.Id,
                BankAccountId = t.BankAccountId,
                BankAccountName = t.BankAccount.Name,
                Amount = t.Amount,
                Date = t.Date,
                Type = t.Type,
                Nature = t.Nature,
                Description = t.Description,
                IsPaid = t.IsPaid,
                PaymentDate = t.PaymentDate ?? DateTime.MinValue,
                CategoryId = t.CategoryId
            })
            .ToListAsync();
    }

    public async Task<TransactionResponse?> GetByIdAsync(int id)
    {
        var t = await _context.Transactions
            .Include(x => x.BankAccount)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if(t == null) return null;

        return new TransactionResponse
        {
            Id = t.Id,
            BankAccountId = t.BankAccountId,
            BankAccountName = t.BankAccount.Name,
            Amount = t.Amount,
            Date = t.Date,
            Type = t.Type,
            Nature = t.Nature,
            Description = t.Description,
            IsPaid = t.IsPaid,
            PaymentDate = t.PaymentDate ?? DateTime.MinValue,
            CategoryId = t.CategoryId
        };
    }

    public async Task<TransactionResponse> CreateAsync(TransactionRequest request)
    {
        var t = new Transaction()
        {
            BankAccountId = request.BankAccountId,
            Amount = request.Amount,
            Date = request.Date,
            Type = request.Type,
            Nature = request.Nature,
            Description = request.Description,
            IsPaid = request.IsPaid,
            PaymentDate = request.IsPaid && request.PaymentDate.HasValue 
                ? request.PaymentDate 
                : null,
            CategoryId = request.CategoryId
        };

        _context.Transactions.Add(t);
        await _context.SaveChangesAsync();

        return new TransactionResponse
        {
            Id = t.Id,
            BankAccountId = t.BankAccountId,
            BankAccountName = _context.BankAccounts.Find(t.BankAccountId)!.Name,
            Amount = t.Amount,
            Date = t.Date,
            Type = t.Type,
            Nature = t.Nature,
            Description = t.Description,
            IsPaid = t.IsPaid,
            PaymentDate = t.PaymentDate,
            CategoryId = t.CategoryId
        };
    }
    
    public async Task<bool> UpdateAsync(int id, TransactionRequest request)
    {
        var entity = await _context.Transactions.FindAsync(id);
        if (entity == null) return false;
        
        entity.BankAccountId = request.BankAccountId;
        entity.Amount = request.Amount;
        entity.Date = request.Date;
        entity.Type = request.Type;
        entity.Nature = request.Nature;
        entity.Description = request.Description;
        entity.IsPaid = request.IsPaid;
        entity.PaymentDate = request.IsPaid ? request.PaymentDate : null;
        entity.CategoryId = request.CategoryId;
        
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Transactions.FindAsync(id);
        if (entity == null) return false;
        
        _context.Transactions.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}