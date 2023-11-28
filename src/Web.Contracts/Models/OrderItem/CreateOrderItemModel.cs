namespace CreateOrderItemRequest;

public sealed class CreateOrderItemRequest
{
    public int OrderId { get; set; }
    
    public string Name { get; set; }
    
    public string Unit { get; set; }
    
    public decimal Quantity { get; set; }
}