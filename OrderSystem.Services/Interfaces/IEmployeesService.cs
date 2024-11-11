using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeesService
    {
        void Delete(int employeeId);
        bool IsRelated(int employeeId);
        bool Exist(Employee employee);
        void Save(Employee employee);
        Employee GetEmployeeById(int employeeId);
        List<EmployeeListDto> GetList(int? currentPage, int? pageSize, Order? orde = Order.None,
            Genre? selectedGenre = null);
        int GetCount(Genre? genre = null);
    }
}
