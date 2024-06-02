namespace WebApplication2.DTO_S;

public record AddProductDTO
{
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }
    public List<int> ProductCategories { get; set; }
}