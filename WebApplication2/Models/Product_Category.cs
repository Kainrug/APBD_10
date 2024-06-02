using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Product_Categories")]
public class Product_Category
{
    [Column("FK_product")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    [Column("FK_category")]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    
    public Product Product { get; set; }
    public Category Category { get; set; }
}