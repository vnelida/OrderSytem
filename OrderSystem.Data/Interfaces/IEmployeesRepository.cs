using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IEmployeesRepository
    {
        void Add(Employee employee, SqlConnection conn, SqlTransaction? tran = null);
        void Delete(int employeeId, SqlConnection conn, SqlTransaction? tran = null);
        void Edit(Employee employee, SqlConnection conn, SqlTransaction? tran = null);
        bool IsRelated(int employeeId, SqlConnection conn, SqlTransaction? tran = null);
        bool Exist(Employee employee, SqlConnection conn, SqlTransaction? tran = null);
        Employee GetEmployeeById(int employeeId, SqlConnection conn, SqlTransaction? tran = null);
        List<EmployeeListDto> GetList(SqlConnection conn, int? currentPage, int? pageSize, Order? order, Genre? selectedGenre);
        int GetCount(SqlConnection conn, Genre? genre = null, SqlTransaction? tran = null);
    }
}
