using Business.Abstract;
using Business.Abstract.Models;

namespace Business.Models.Order;

public sealed class CreateOrderModel : ICreateModel
{
    public CreateOrderModel(
        string number,
        DateTime date,
        int providerId)
    {
        Number = number;
        Date = date;
        ProviderId = providerId;
    }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
}