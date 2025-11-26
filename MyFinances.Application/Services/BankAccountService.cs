using Microsoft.EntityFrameworkCore;
using MyFinances.Application.DTOs.Responses;
using MyFinances.Application.DTOs.Requests;
using MyFinances.Application.Services.Interfaces;
using MyFinances.Data.Context;
using MyFinances.Domain.Entities;

public class BankAccountService : IBankAccountService
{
    private readonly MyFinancesDbContext _context;

    public BankAccountService(MyFinancesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BankAccountResponse>> GetAllAsync()
    {
        return await _context.BankAccounts
            .Select(x => new BankAccountResponse
            {
                Id = x.Id,
                Name = x.Name,
                Bank = x.Bank,
                Number = x.Number,
                InitialBalance = x.InitialBalance,
                CurrentBalance = x.InitialBalance +
                    x.Transactions.Sum(t => 
                        t.Type == TransactionType.Income ? t.Amount : -t.Amount
                    )
            })
            .ToListAsync();
    }

    public async Task<BankAccountResponse?> GetByIdAsync(int id)
    {
        var entity = await _context.BankAccounts
            .Include(x => x.Transactions)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null) return null;

        return new BankAccountResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Bank = entity.Bank,
            Number = entity.Number,
            InitialBalance = entity.InitialBalance,
            CurrentBalance = entity.InitialBalance +
                entity.Transactions.Sum(t => 
                    t.Type == TransactionType.Income ? t.Amount : -t.Amount
                )
        };
    }

    public async Task<BankAccountResponse> CreateAsync(BankAccountRequest request)
    {
        var entity = new BankAccount
        {
            Name = request.Name,
            Bank = request.Bank,
            Number = request.Number,
            InitialBalance = request.InitialBalance
        };

        _context.BankAccounts.Add(entity);
        await _context.SaveChangesAsync();

        return new BankAccountResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Bank = entity.Bank,
            Number = entity.Number,
            InitialBalance = entity.InitialBalance,
            CurrentBalance = entity.InitialBalance
        };
    }

    public async Task<bool> UpdateAsync(int id, BankAccountRequest request)
    {
        var entity = await _context.BankAccounts.FindAsync(id);
        if (entity == null) return false;
        
        entity.Name = request.Name;
        entity.Bank = request.Bank;
        entity.Number = request.Number;
        entity.InitialBalance = request.InitialBalance;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.BankAccounts.FindAsync(id);
        if (entity == null) return false;

        _context.BankAccounts.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }
}
