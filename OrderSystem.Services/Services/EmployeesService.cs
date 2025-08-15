using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Services.Interfaces;
using System.Data.SqlClient;

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

        public int GetCount(Genre? genreFilter)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCount(conn, genreFilter);

            }
        }

        public Employee GetEmployeeById(int employeeId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetEmployeeById(employeeId, conn);
            }
        }
        public List<EmployeeListDto> GetList(int? currentPage, int? pageSize, Order? order = Order.None, Genre? selectedGenre = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn, currentPage, pageSize, order, selectedGenre);
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
