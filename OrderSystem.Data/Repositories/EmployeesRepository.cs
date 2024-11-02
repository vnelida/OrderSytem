using Dapper;
using Data.Interfaces;
using Entities.Entities;
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
            string insertQuery = @"INSERT INTO Employees (FirstName, LastName, Phone, Email, Address) 
                    VALUES(@FirstName, @LastName, @Phone, @Email, @Address); SELECT CAST(SCOPE_IDENTITY() as int)";

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
                    SET FirstName=@FirstName, LastName=@LastName, Phone=@Phone, Email=@Email, Address=@Address
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
                    conditional = "WHERE FirstName = @FirstName and LastName=@LastName";
                }
                else
                {
                    conditional = @"WHERE FirstName = @FirstName
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

        public List<Employee> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT EmployeeId, FirstName, LastName, Phone, Email, Address FROM 
                    Employees ORDER BY LastName";
            return conn.Query<Employee>(selectQuery).ToList();
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
