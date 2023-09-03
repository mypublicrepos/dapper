using Dapper;
using WebApi.Infrastructure.Entity;
using WebApi.Infrastructure.Repository.Contract;
using WebApi.Models.Response;
using System.Data;

namespace WebApi.Infrastructure.Repository.Concrete;

/// <summary> </summary>
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary> </summary>
    /// <param name="context"></param>
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary> </summary>
    /// <param name="email"></param>
    /// <param name="contact"></param>
    /// <returns></returns>
    public async Task<UserResponseModel> GetUserByEmailAndContact(string email, string contact)
    {
        var query = "SELECT * FROM User WHERE Email = @email And Contact = @contact";
        using (var connection = _context.CreateConnection())
        {
            var user = await connection.QuerySingleOrDefaultAsync<UserResponseModel>(query, new { email, contact });
            return user;
        }
    }

    /// <summary> </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserResponseModel> GetUserById(Guid id)
    {
        var query = "SELECT * FROM User WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var user = await connection.QuerySingleOrDefaultAsync<UserResponseModel>(query, new { id });
            return user;
        }
    }

    /// <summary> </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<UserResponseModel> LoginAsync(string email)
    {
        var query = "SELECT * FROM User WHERE Email = @email";
        using (var connection = _context.CreateConnection())
        {
            var userResponse = await connection.QuerySingleOrDefaultAsync<UserResponseModel>(query, new { email });
            return userResponse;
        }
    }

    /// <summary></summary>
    /// <param name="userEntity"></param>
    /// <param name="credentials"></param>
    /// <returns></returns>
    public async Task<bool> SaveuserAsync(User userEntity, Credentials credentials)
    {
        bool response = false;
        var guid = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        #region "User Query"
        var userQuery = "INSERT INTO User (Id, Name, Email, Contact, Gender) VALUES (@Id, @Name, @Email, @Contact, @Gender)";

        var userParameters = new DynamicParameters();
        userParameters.Add("Id", guid.ToString(), DbType.String);
        userParameters.Add("Name", userEntity.Name , DbType.String);
        userParameters.Add("Email", userEntity?.Email, DbType.String);
        userParameters.Add("Contact", userEntity?.Contact, DbType.String);
        userParameters.Add("Gender", userEntity?.Gender, DbType.Int16);
        #endregion

        #region Credentials
        var credQuery = @"INSERT INTO Credentials (Id, Hash, Salt, UserId, RoleId)  VALUES (@Id, @Hash, @Salt, @UserId, @RoleId);";
        var credParameters = new DynamicParameters();
        credParameters.Add("Id", guid2.ToString(), DbType.String);
        credParameters.Add("Hash", credentials.Hash, DbType.String);
        credParameters.Add("Salt", credentials?.Salt, DbType.String);
        credParameters.Add("UserId", guid.ToString(), DbType.String);
        credParameters.Add("RoleId", credentials?.RoleId, DbType.Guid);
        #endregion

        using (var connection = _context.CreateConnection())
        {
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {  
                try
                {
                    await connection.ExecuteAsync(userQuery, userParameters, transaction: transaction);
                    await connection.ExecuteAsync(credQuery, credParameters, transaction: transaction);
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
