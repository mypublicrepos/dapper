using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Business.Contract;

public interface IRoleBusiness
{
    Task<bool> SaveRoleAsync(RoleModel role);

    Task<List<RoleModelResponse>> GetRoleAsync();
}
