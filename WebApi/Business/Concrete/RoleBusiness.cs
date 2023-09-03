using AutoMapper;
using WebApi.Business.Contract;
using WebApi.Infrastructure.Entity;
using WebApi.Infrastructure.Repository.Contract;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Business.Concrete;

public class RoleBusiness : IRoleBusiness
{
    private readonly IRoleRepository roleRepository;
    private readonly ILogger<RoleBusiness> logger;
    private readonly IMapper mapper;

    /// <summary> </summary>
    /// <param name="roleRepository"></param>
    /// <param name="logger"></param>
    public RoleBusiness(IRoleRepository roleRepository, ILogger<RoleBusiness> logger, IMapper mapper)
    {
        this.roleRepository = roleRepository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public async Task<List<RoleModelResponse>> GetRoleAsync()
    {
        var data = await roleRepository.GetRolesAsync();
        var response = mapper.Map<List<RoleModelResponse>>(data);
        return response;
    }

    public async Task<bool> SaveRoleAsync(RoleModel role)
    {
        var entity = mapper.Map<Role>(role);
        var response = await roleRepository.SaveRoleAsync(entity);
        return response;
    }
}
