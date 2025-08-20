using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public void Add(User user, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Users
                                    (UserName, Password, RoleId, IsActive)
                                    VALUES (@UserName, @Password, @RoleId, @IsActive);
                                    SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, user, tran);
            if (primaryKey > 0)
            {
                user.UserId = primaryKey;
                return;
            }
            throw new Exception("User could not be added");
        }

        public void Delete(int userId, SqlConnection conn, SqlTransaction tran)
        {
            var deleteQuery = @"DELETE FROM Users 
                WHERE UserId=@UserId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { userId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("Error");
            }
        }

        public void Edit(User user, SqlConnection conn, SqlTransaction tran)
        {
            var updateQuery = @"UPDATE Users 
                               SET UserName=@UserName,
                                   Password=@Password,
                                   RoleId=@RoleId,
                                   IsActive=@IsActive
                                   WHERE UserId=@UserId";
            
            int registrosAfectados = conn.Execute(updateQuery, user, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("User could not be edited");
            }
        }

        public bool Exist(User user, SqlConnection conn)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Users ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = user.UserId == 0 ?
                " WHERE UserName=@UserName AND RoleId=@RoleId" :
                " WHERE UserName=@UserName AND RoleId=@RoleId " +
                "AND UserId<>@UserId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, user) > 0;
        }

        public List<UserListDto> GetList(SqlConnection conn)
        {
            var selectQuery = @"select u.UserId, u.UserName, r.RoleName, u.IsActive
                                from Users u inner join Roles r on u.RoleId=r.RoleId";


            return conn.Query<UserListDto>(selectQuery).ToList();
        }

        public User? GetUser(string user, string password, SqlConnection conn)
        {
            var selectQuery = @"SELECT u.UserId, u.UserName, u.Password, u.RoleId, u.IsActive, 
                                       r.RoleId, r.RoleName, r.Description,
                                       pr.PermissionRoleId, pr.RoleId as PrRoleId, pr.PermissionId as PrPermissionId, 
                                       p.PermissionId, p.Menu
                                FROM Users u
                                INNER JOIN Roles r ON u.RoleId = r.RoleId
                                INNER JOIN PermissionsRoles pr ON r.RoleId = pr.RoleId
                                INNER JOIN Permissions p ON p.PermissionId = pr.PermissionId
                                WHERE u.UserName = @User AND u.Password = @Password AND u.IsActive = 1
                                ";

            var userDictionary = new Dictionary<int, User>();

            var resultado = conn.Query<User, Rol, PermissionRol, Permission, User>(
                selectQuery,
                (user, role, permissionRole, permission) =>
                {
                    if (!userDictionary.TryGetValue(user.UserId, out var userEntry))
                    {
                        userEntry = user;
                        userEntry.Rol = role;
                        userEntry.Rol.Permissions = new List<PermissionRol>();
                        userDictionary.Add(user.UserId, userEntry);
                    }

                    permissionRole.Permission = permission;
                    userEntry.Rol.Permissions.Add(permissionRole);

                    return userEntry;
                },
                new { User = user, Password = password },
                splitOn: "RoleId, PermissionRoleId, PermissionId"
            ).ToList();

            return userDictionary.Values.FirstOrDefault();
        }

        public User GetUserById(int userId, SqlConnection conn)
        {
            var selectQuery = @"SELECT UserId, 
                UserName, Password, IsActive, RoleId FROM Users 
                WHERE UserId=@UserId";

            return conn.QueryFirstOrDefault<User>(selectQuery, new { userId });
        }
    }

}
