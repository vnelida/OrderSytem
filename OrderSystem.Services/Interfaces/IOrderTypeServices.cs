using Entities.Entities;

namespace Services.Interfaces
{
    public interface IOrderTypeServices
    {
        OrderType? GetOrderTypeByName(string typeName);
        List<OrderType> GetListOrderType();
    }
}
