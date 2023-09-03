using Dapper;
using WebApi.Infrastructure.Entity;
using WebApi.Infrastructure.Repository.Contract;
using WebApi.Models.Response;
using System.Data;
using System.Data.Common;

namespace WebApi.Infrastructure.Repository.Concrete;

/// <summary> </summary>
public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary> </summary>
    /// <param name="context"></param>
    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary> </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<Role>> GetRolesAsync()
    {
        var query = "SELECT * FROM Role";
        using (var connection = _context.CreateConnection())
        {
            var roles = (await connection.QueryAsync<Role>(query)).AsList();
            return roles;
        }
    }

    public async Task<bool> SaveRoleAsync(Role role)
    {
        bool response = false;
        #region "User Query"
        var query = "INSERT INTO Role(Id, RoleName) VALUES (@Id, @Rolename)";

        var parameters = new DynamicParameters();
        parameters.Add("Id", new Guid(), DbType.Guid);
        parameters.Add("RoleName", role.RoleName, DbType.String);
        #endregion

        using(var connection = _context.CreateConnection())
        {
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                await connection.ExecuteAsync(query, parameters, transaction: transaction);
                try
                {
                    transaction.Commit();
                    response = true;
                }
                catch (Exception ex)
                {
                    response = false;
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        return response;
    }
}
