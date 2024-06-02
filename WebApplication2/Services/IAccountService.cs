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
    Task AddProductAsync(AddProductDTO addProduct);
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

    public async Task AddProductAsync(AddProductDTO addProduct)
    {

        var result = new Product
        {
            ProductName = addProduct.Name,
            ProductWeight = addProduct.Weight,
            ProductWidth = addProduct.Width,
            ProductHeight = addProduct.Height,
            ProductDepth = addProduct.Depth,
        };
        
        
        if (addProduct.Name is null)
        {
            throw new AddProductException("You must type product name");
        }

        
        foreach (var productCategory in addProduct.ProductCategories)
        {
            var category = await context.Categories.FindAsync(productCategory);
            if (category == null)
            {
                throw new AddProductException($"Category with id {productCategory} does not exist.");
            }
        }

        var product = new Product
        {
            ProductName = addProduct.Name,
            ProductWidth = addProduct.Width,
            ProductHeight = addProduct.Height,
            ProductDepth = addProduct.Depth,
            ProductCategories = addProduct.ProductCategories.Select(categoryId => new Product_Category()
            {
                CategoryId = categoryId
            }).ToList()
        };
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }
}
