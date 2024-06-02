using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;
[Table("Shopping_Carts")]
public class ShoppingCart
{
    
    [Column("FK_account")]
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    
    
    [Column("FK_product")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    [Column("amount")]
    public int Amount { get; set; }

    public Account Account { get; set; }
    public Product Product { get; set; }
}