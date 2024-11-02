using Entities.Entities;
using System;
using System.Collections.Generic;
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
        List<Employee> GetList();
        void Save(Employee employee);

    }
}
