using WebApi.Infrastructure.Entity;

namespace WebApi.Infrastructure.Repository.Contract;

public interface IRoleRepository
{
    Task<bool> SaveRoleAsync(Role role);

    Task<List<Role>> GetRolesAsync();
}
