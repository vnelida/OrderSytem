using Entities.Entities;

namespace Services.Interfaces
{
    public interface IOrderStatusService
    {
        OrderStatus? GetOrderStatusByName(string statusName);
        List<OrderStatus> GetListOrderStatus();
    }
}
