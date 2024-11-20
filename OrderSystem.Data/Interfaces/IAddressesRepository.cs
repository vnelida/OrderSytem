using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IAddressesRepository
    {
        int GetAddressIdIfExists(Address address, SqlConnection conn, SqlTransaction? tran = null);
        void Add(Address address, SqlConnection conn, SqlTransaction? tran = null);
        Address? GetAddressById(int addressId, SqlConnection conn, SqlTransaction? tran = null);
        List<Address> GetDAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
