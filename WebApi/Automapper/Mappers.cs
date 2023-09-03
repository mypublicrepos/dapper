using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using WebApi.Infrastructure.Entity;
using WebApi.Models.Request;

namespace WebApi.Automapper;

public class Mappers : Profile
{
    /// <summary> </summary>
    /// <param name="provider"></param>
    public Mappers(IDataProtector provider)
    {
        CreateMap<UserModel, User>().ReverseMap();
        CreateMap<RoleModel, Role>().ReverseMap();
    }
}
