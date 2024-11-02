using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository? _repository;
        private readonly string? _cadena;
        public EmployeesService(IEmployeesRepository? repository, string? cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }

        public void Delete(int employeeId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository!.Delete(employeeId, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }

                }
            }
        }

        public bool Exist(Employee employee)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.Exist(employee, conn);

            }
        }

        public List<Employee> GetList()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetList(conn);

            }
        }

        public bool IsRelated(int employeeId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.IsRelated(employeeId, conn);
            }
        }

        public void Save(Employee employee)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (employee.EmployeeId == 0)
                        {
                            _repository!.Add(employee, conn, tran);
                        }
                        else
                        {
                            _repository!.Edit(employee, conn, tran);
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }

                }
            }
        }
    }
}
