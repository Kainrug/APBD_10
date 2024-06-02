using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.DTO_S;
using WebApplication2.Exceptions;
using WebApplication2.Models;
using WebApplication2.ResponseModels;

namespace WebApplication2.Services;

public interface IAccountService
{
    Task<GetAccountsResponseModel> GetAccountByIdAsync(int id);
}

public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountsResponseModel> GetAccountByIdAsync(int id)
    {
        var response = await context.Accounts
            .Where(a => a.AccountId == id)
            .Select(a => new GetAccountsResponseModel()
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Phone = a.Phone,
                Role = a.Role.RoleName,
                Carts = context.ShoppingCarts
                    .Where(sc => sc.AccountId == id)
                    .Select(sc => new Cart
                    {
                        ProductId = sc.ProductId,
                        ProductName = sc.Product.ProductName,
                        Amount = sc.Amount
                    }).ToList()
            }).FirstOrDefaultAsync();

        if (response is null)
        {
            throw new NotFoundException($"Account with {id} does not exist");
        }
        return response;
    }
}
