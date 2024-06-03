using FluentValidation;
using WebApplication2.DTO_S;
using WebApplication2.Exceptions;
using WebApplication2.ResponseModels;
using WebApplication2.Services;

namespace WebApplication2.Endpoints;

public static class AccountByIdEndpoint
{
    public static void RegisterAccountById(this WebApplication app)
    {
        var product = app.MapGroup("products");
        product.MapGet("accounts/{id:int}", GetAccountById);
        product.MapPost("products", AddProduct);
    }
    
    
    private static async Task<IResult> GetAccountById(int id, IAccountService db)
    {
        try
        {
            return Results.Ok(await db.GetAccountByIdAsync(id));
        }
        catch (NotFoundException e)
        {
            return Results.NotFound(e.Message);
        }
    }
    
    private static async Task<IResult> AddProduct(AddProductDTO newProduct, IProductService db, IValidator<AddProductDTO> validator)
    {
        
        var validate = await validator.ValidateAsync(newProduct);
        if (!validate.IsValid)
        {
            return Results.ValidationProblem(validate.ToDictionary());
        }
        try
        {
            await db.AddProductAsync(newProduct);
        }
        catch (AddProductException exception)
        {
            return Results.BadRequest(exception.Message);
        }

        return Results.Created();
    }
}