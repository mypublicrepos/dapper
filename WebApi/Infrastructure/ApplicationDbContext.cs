using MySqlConnector;
using System.Data;

namespace WebApi.Infrastructure;

public class ApplicationDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SqlConnection");
    }
    public IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}
