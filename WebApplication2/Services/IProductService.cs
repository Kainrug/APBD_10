using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.DTO_S;
using WebApplication2.Exceptions;
using WebApplication2.Models;
using WebApplication2.ResponseModels;

namespace WebApplication2.Services;

public interface IProductService
{
    Task AddProductAsync(AddProductDTO addProduct);
}

public class ProductService(DatabaseContext context) : IProductService {

    public async Task AddProductAsync(AddProductDTO addProduct)
    {
        
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