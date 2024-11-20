using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICustomerPhonesRepository
    {
        void Add(CustomerPhone customerPhone, SqlConnection conn, SqlTransaction? tran = null);
        void DeleteCustomerById(int customerId, SqlConnection conn, SqlTransaction? tran = null);
        List<CustomerPhone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
