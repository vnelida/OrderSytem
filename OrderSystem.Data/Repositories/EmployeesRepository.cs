using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public void Add(Employee employee, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO Employees (FirstName, LastName, Phone, Email, Address, Dni, DateOfBirth, GenreId) 
                    VALUES(@FirstName, @LastName, @Phone, @Email, @Address, @Dni, @DateOfBirth, @GenreId); SELECT CAST(SCOPE_IDENTITY() as int)";

            var primaryKey = conn.QuerySingle<int>(insertQuery, employee, tran);
            if (primaryKey > 0)
            {

                employee.EmployeeId = primaryKey;
                return;
            }

            throw new Exception("The employee could not be added");
        }

        public void Delete(int employeeId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM Employees 
                    WHERE EmployeeId=@EmployeeId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { employeeId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("The employee could not be deleted");
            }
        }

        public void Edit(Employee employee, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE Employees 
                    SET FirstName=@FirstName, LastName=@LastName, Phone=@Phone, Email=@Email, Address=@Address, Dni=@Dni, DateOfBirth=@DateOfBirth, GenreId=@GenreId
                    WHERE EmployeeId=@EmployeeId";

            int registrosAfectados = conn.Execute(updateQuery, employee, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("The employee could not be updated");
            }
        }

        public bool Exist(Employee employee, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Employees ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (employee.EmployeeId == 0)
                {
                    conditional = "WHERE Dni = @Dni";
                }
                else
                {
                    conditional = @"WHERE Dni = @Dni
                            AND EmployeeId<>@EmployeeId";
                }//revisar de nuevo 
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, employee) > 0;

            }
            catch (Exception)
            {

                throw new Exception("The employee could not be verified.");
            }
        }

        public int GetCount(SqlConnection conn, Genre? genre = null, SqlTransaction? tran = null)
        {
            var query = "SELECT COUNT(*) FROM Employees";
            if (genre != null)
            {
                query += " WHERE GenreId = @GenreId";
                return conn.ExecuteScalar<int>(query, new { GenreId = genre.GenreId });
            }
            return conn.ExecuteScalar<int>(query);
        }

        public Employee? GetEmployeeById(int employeeId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT EmployeeId, FirstName, LastName, Phone, Email, Address, Dni, DateOfBirth, GenreId FROM Employees 
                WHERE EmployeeId=@EmployeeId";

            return conn.QueryFirstOrDefault<Employee>(selectQuery, new { employeeId });
        }

        public List<EmployeeListDto> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT EmployeeId, FirstName, LastName, Phone, Email, Address, Dni, DateOfBirth, GenreName FROM Employees e INNER JOIN Genres g on g.GenreId=e.GenreId ORDER BY FirstName";
            return conn.Query<EmployeeListDto>(selectQuery).ToList();
        }

        public List<EmployeeListDto> GetList(SqlConnection conn, int? currentPage, int? pageSize, Order? order, Genre? selectedGenre)
        {
            var selectQuery = @"SELECT EmployeeId, FirstName, LastName, Phone, Email, Address, Dni, DateOfBirth, GenreName FROM Employees e INNER JOIN Genres g on g.GenreId=e.GenreId ";

            List<string> conditions = new List<string>();

            if (selectedGenre != null)
            {
                conditions.Add("g.GenreId=@GenreId");
            }

            if (conditions.Any())
            {
                selectQuery += " WHERE " + string.Join(" AND ", conditions);
            }
            string orderBy = string.Empty;

            switch (order)
            {
                case Order.None:
                    orderBy = " ORDER BY EmployeeId DESC ";
                    break;
                case Order.FirstNameAZ:
                    orderBy = " ORDER BY FirstName ";
                    break;
                case Order.FirstNameZA:
                    orderBy = " ORDER BY FirstName DESC ";
                    break;
                case Order.LastNameAZ:
                    orderBy = " ORDER BY LastName ";
                    break;
                default:
                    orderBy = " ORDER BY LastName DESC ";
                    break;
            }
            selectQuery += orderBy;

            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return conn.Query<EmployeeListDto>(selectQuery, new { GenreId = selectedGenre?.GenreId }).ToList();
        }

        public bool IsRelated(int employeeId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) 
                            FROM Employees 
                                WHERE EmployeeId=@EmployeeId";
            return conn.
                QuerySingle<int>(selectQuery, new { employeeId }) > 0;
        }
    }
}
