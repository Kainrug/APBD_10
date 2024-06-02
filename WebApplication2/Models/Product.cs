using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string? ProductName { get; set; }
    
    [Column("weight")]
    public decimal ProductWeight { get; set; }
    
    [Column("width")]
    public decimal ProductWidth { get; set; }
    
    [Column("height")]
    public decimal ProductHeight { get; set; }
    
    [Column("depth")]
    public decimal ProductDepth { get; set; }

    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    
    public IEnumerable<Product_Category> ProductCategories { get; set; }
}