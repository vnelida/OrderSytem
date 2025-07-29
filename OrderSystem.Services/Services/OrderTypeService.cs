using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class OrderTypeService : IOrderTypeServices
    {
        private readonly IOrderTypeRepository? _repository;
        private readonly string? _cadena;
        public OrderTypeService(IOrderTypeRepository? repository, string? cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }
        public List<OrderType> GetListOrderType()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetListOrderType(conn);
            }
        }

        public OrderType? GetOrderTypeByName(string typeName)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                var types = _repository!.GetOrderTypeByName(typeName, conn);
                return types;
            }
        }
    }
}
