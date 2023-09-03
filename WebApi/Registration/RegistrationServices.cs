using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using WebApi.Automapper;
using WebApi.Business.Concrete;
using WebApi.Business.Contract;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Repository.Concrete;
using WebApi.Infrastructure.Repository.Contract;

namespace WebApi.Registration;

public static class RegistrationServices
{

    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ApplicationDbContext>();
        AutoMapperRegistration(builder);
        RegisterDependency(builder);
        return builder;
    }

    private static void RegisterDependency(WebApplicationBuilder builder)
    {
        #region "Business Register"
        builder.Services.AddScoped<IUserBusiness, UserBusiness>();
        builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
        #endregion

        #region "Repository Register"
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<ICredentialsRepository, CredentialsRepository>();
        #endregion
    }

    private static void AutoMapperRegistration(WebApplicationBuilder builder)
    {
        builder.Services.AddDataProtection();
        var serviceProvider = builder.Services.BuildServiceProvider();
        var _provider = serviceProvider.GetService<IDataProtectionProvider>();
        var protector = _provider.CreateProtector(builder.Configuration["Protector_Key"]);
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new Mappers(protector));
        });
        IMapper autoMapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(autoMapper);
    }
}