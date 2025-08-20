using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository? _repository;
        private readonly string? _cadena;
        public PaymentMethodService(IPaymentMethodRepository? repository, string? cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }
        public List<PaymentMethod> GetList()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetList(conn);
            }
        }
    }
}
