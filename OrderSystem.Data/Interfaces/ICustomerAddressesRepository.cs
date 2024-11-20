using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface ICustomerAddressesRepository
    {
        void Add(CustomerAddress customerAddress, SqlConnection conn, SqlTransaction? tran = null);
        void DeleteByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null);
        List<CustomerAddress> GetAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
