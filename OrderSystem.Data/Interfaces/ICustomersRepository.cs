using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICustomersRepository
    {
        void Delete(int customerId, SqlConnection conn, SqlTransaction? tran = null);

        void Add(Customer customer, SqlConnection conn, SqlTransaction? tran = null);

        bool Exist(Customer customer, SqlConnection conn, SqlTransaction? tran = null);

        void Edit(Customer customer, SqlConnection conn, SqlTransaction? tran = null);
        Customer? GetCustomerById(int customerId, SqlConnection conn);
        List<CustomerListDto> GetList(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null);
        int GetCount(SqlConnection conn);
        CustomerDetailsDto? GetCustomerDetails(int customerId, SqlConnection conn, SqlTransaction? tran = null);
        List<Customer> GetCustomers(SqlConnection conn);
    }
}
