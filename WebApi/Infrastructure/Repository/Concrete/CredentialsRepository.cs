using Dapper;
using WebApi.Infrastructure.Repository.Contract;
using WebApi.Models.Response;

namespace WebApi.Infrastructure.Repository.Concrete;

public class CredentialsRepository : ICredentialsRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary> </summary>
    /// <param name="context"></param>
    public CredentialsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HashSaltResponseModel> GetCredentials(Guid userId)
    {
        var query = "SELECT * FROM Credentials WHERE UserId = @userId";
        using (var connection = _context.CreateConnection())
        {
            var hashDetails = await connection.QuerySingleOrDefaultAsync<HashSaltResponseModel>(query, new { userId });
            return hashDetails;
        }
    }
}
