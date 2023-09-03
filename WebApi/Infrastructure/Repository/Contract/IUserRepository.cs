using WebApi.Infrastructure.Entity;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Infrastructure.Repository.Contract;

public interface IUserRepository
{
    /// <summary> </summary>
    /// <param name="userModel"></param>
    /// <param name="credentials"></param>
    /// <returns></returns>
    Task<bool> SaveuserAsync(User userEntity, Credentials credentials);

    /// <summary> </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserResponseModel> GetUserById(Guid id);

    /// <summary> </summary>
    /// <param name="email"></param>
    /// <param name="contact"></param>
    /// <returns></returns>
    Task<UserResponseModel> GetUserByEmailAndContact(string email, string contact);

    /// <summary> </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<UserResponseModel> LoginAsync(string email);
}
