using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPhoneTypesService
    {
        List<PhoneType> GetList(SqlConnection conn, SqlTransaction? tran = null);
    }
}
