using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Business.Contract;

public interface IUserBusiness
{
    /// <summary> </summary>
    /// <param name="userModel"></param>
    /// <returns></returns>
    Task<bool> SaveuserAsync(UserModel userModel);

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
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UserResponseModel> LoginAsync(UserLoginModel user);
}
