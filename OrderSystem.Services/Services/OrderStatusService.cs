using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository? _repository;
        private readonly string? _cadena;
        public OrderStatusService(IOrderStatusRepository? repository, string? cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }
        public List<OrderStatus> GetListOrderStatus()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetListOrderStatus(conn);
            }
        }

        public OrderStatus? GetOrderStatusByName(string statusName)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                var status = _repository!.GetOrderStatusByName(statusName, conn);
                return status;
            }
        }
    }
}
