namespace Web.Contracts.Models.Order;

public sealed class CreateOrderRequest
{
    public string? Number { get; set; }
    
    public DateTime? Date { get; set; }
    
    public int? ProviderId { get; set; }
}