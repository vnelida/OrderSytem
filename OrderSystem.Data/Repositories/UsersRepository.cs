using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public User? GetUser(string user, string password, SqlConnection conn)
        {
            var selectQuery = @"
        SELECT u.UserId, u.UserName, u.Password, u.RoleId, u.IsActive, 
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

                    // Asignar el objeto de permiso a PermissionRol antes de agregarlo
                    permissionRole.Permission = permission;
                    userEntry.Rol.Permissions.Add(permissionRole);

                    return userEntry;
                },
                new { User = user, Password = password },
                splitOn: "RoleId, PermissionRoleId, PermissionId"
            ).ToList();

            return userDictionary.Values.FirstOrDefault();
            //var selectQuery = @"
            //    SELECT u.UserId, u.UserName, u.Password, u.RoleId, u.IsActive, 
            //            r.RoleId, r.RoleName, 
            //            pr.PermissionRoleId, pr.RoleId, pr.PermissionId, 
            //            p.PermissionId, p.Menu
            //     FROM Users u
            //     INNER JOIN Roles r ON u.RoleId = r.RoleId
            //     INNER JOIN PermissionsRoles pr ON pr.RoleId = r.RoleId
            //     INNER JOIN Permissions p ON p.PermissionId = pr.PermissionId
            //     WHERE u.UserName = @user AND u.Password =@Password AND u.IsActive = 1";

            //var usuarioDictionary = new Dictionary<int, User>();

            //var resultado = conn.Query<User, Rol, PermissionRol, Permission, User>(
            //    selectQuery,
            //    (user, role, permissionRole, permission) =>
            //    {
            //        // Verificar si el usuario ya existe en el diccionario
            //        if (!usuarioDictionary.TryGetValue(user.UserId, out var usuarioEntry))
            //        {
            //            // Crear una nueva instancia de usuario si no está en el diccionario
            //            usuarioEntry = user;
            //            usuarioEntry.Rol = role;
            //            usuarioEntry.Rol.Permissions = new List<PermissionRol>(); // Inicializamos la lista de permisos
            //            usuarioDictionary.Add(user.UserId, usuarioEntry);
            //        }

            //        // Verificar si el permisoRol ya existe en la lista de permisos del rol
            //        if (!usuarioEntry.Rol.Permissions.Any(p => p.PermissionRolId == permissionRole.PermissionRolId))
            //        {
            //            // Asociar el permiso correspondiente al PermisoRol
            //            permissionRole.Permission = permission;
            //            // Agregar el PermisoRol al Rol
            //            usuarioEntry.Rol.Permissions.Add(permissionRole);
            //        }

            //        return usuarioEntry; // Devolver siempre la referencia actualizada del usuario
            //    },
            //    new { User = user, Password = password },
            //    splitOn: "RoleId, PermissionRoleId, PermissionId");//Campos donde se hacen los cortes

            //// Retornar el primer usuario encontrado o null si no se encontró ninguno
            //return usuarioDictionary.Values.FirstOrDefault();
        }
    }
    
}
