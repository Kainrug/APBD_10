namespace WebApplication2.ResponseModels;

public class GetAccountsResponseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Role { get; set; }
    public List<Cart> Carts { get; set; }
}


public class Cart {
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
}