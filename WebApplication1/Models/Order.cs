namespace WebApplication1.Models;

/// <summary>
/// 注文情報
/// </summary>
public class Order
{
    public string CustomerName { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    public Status Status { get; set; }
    public Product[] Product { get; set; } = null!;
}
