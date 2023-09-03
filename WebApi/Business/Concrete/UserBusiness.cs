using AutoMapper;
using WebApi.Business.Contract;
using WebApi.Common.Models;
using WebApi.Infrastructure.Entity;
using WebApi.Infrastructure.Repository.Contract;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Business.Concrete;

public class UserBusiness : IUserBusiness
{
    private readonly IUserRepository userRepository;
    private readonly ICredentialsRepository credentialsRepository;
    private readonly ILogger<RoleBusiness> logger;
    private readonly IMapper mapper;
    public UserBusiness(IUserRepository userRepository, ILogger<RoleBusiness> logger, IMapper mapper, ICredentialsRepository credentialsRepository)
    {
        this.userRepository = userRepository;
        this.logger = logger;
        this.mapper = mapper;
        this.credentialsRepository = credentialsRepository;

    }

    /// <summary>Return user By Id</summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<UserResponseModel> GetUserById(Guid id)
    {
        var data = await userRepository.GetUserById(id);
        return data;
    }

    public async Task<UserResponseModel> LoginAsync(UserLoginModel user)
    {
        var data = await userRepository.LoginAsync(user.Email);
        if(data is not null)
        {
            var cred = await credentialsRepository.GetCredentials(data.Id);
            var pswdResponse = user.Password.VerifyPassword(cred.Salt, cred.Hash);
        }
        return data;
    }

    public async Task<bool> SaveuserAsync(UserModel userModel)
    {
        var entity = mapper.Map<User>(userModel);
        var hashSalt = userModel?.Password.Passecurity();
        var credentialEntity = new Credentials()
        {
            Hash = hashSalt.Value.Item2,
            Salt = hashSalt.Value.Item1,
            RoleId = userModel.RoleId
        };
        var response = await userRepository.SaveuserAsync(entity, credentialEntity);
        return response;
    }

    /// <summary>
    /// this will private method later
    /// </summary>
    /// <param name="email"></param>
    /// <param name="contact"></param>
    /// <returns></returns>
    public async Task<UserResponseModel> GetUserByEmailAndContact(string email, string contact)
    {
        var response = await userRepository.GetUserByEmailAndContact(email, contact);
        return response;
    }
}
