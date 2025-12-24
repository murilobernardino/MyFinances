using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFinances.Application.Services;
using MyFinances.Application.Services.Interfaces;
using MyFinances.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyFinancesDbContext>(options =>
    options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            sql => sql.EnableRetryOnFailure()
        )
        .UseLazyLoadingProxies()
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyFinancesDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();