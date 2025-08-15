using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IComboDetailsRepository
    {
        void Add(ComboDetail detail, SqlConnection conn, SqlTransaction tran);
        void Delete(int itemId, SqlConnection conn, SqlTransaction tran);
        IEnumerable<ComboDetail> GetComboDetails(int comboId, SqlConnection conn, SqlTransaction tran);
    }
}
