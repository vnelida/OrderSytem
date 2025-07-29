using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderStatusService
    {
        OrderStatus? GetOrderStatusByName(string statusName);
        List<OrderStatus> GetListOrderStatus();
    }
}
