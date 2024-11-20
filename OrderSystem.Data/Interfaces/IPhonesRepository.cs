using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPhonesRepository
    {
        void Add(Phone phone, SqlConnection conn, SqlTransaction? tran = null);
        int GetPhoneIdIfExist(Phone phone, SqlConnection conn, SqlTransaction tran);
        Phone? GetPhoneById(int phoneId, SqlConnection conn, SqlTransaction? tran = null);
        List<Phone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
