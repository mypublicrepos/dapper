using WebApi.Models.Response;

namespace WebApi.Infrastructure.Repository.Contract;

public interface ICredentialsRepository
{
    /// <summary>
    /// return Role Hash and Salt
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<HashSaltResponseModel> GetCredentials (Guid userId);
}