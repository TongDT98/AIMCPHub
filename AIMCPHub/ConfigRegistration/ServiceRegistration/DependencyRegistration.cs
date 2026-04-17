using App.Bussiness.Implements;
using App.Bussiness.Interfaces;
using App.DAL.Repositories.Implements;
using App.DAL.Repositories.Interfaces;

namespace AIMCPHub.ConfigRegistration.ServiceRegistration
{
    public static class DependencyRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserPermissionRepository,UserPermissionRepository>();
            services.AddTransient<IPermissionRepository,PermissionRepository>();
            services.AddTransient<IRolePermissionModuleRepository,RolePermissionModuleRepository>();
            services.AddTransient<IPermissionModuleRepository,PermisionModuleRepository>();
            services.AddTransient<IRoleRepository,RoleRepository>();
            services.AddTransient<ITransactionRepository,TransactionRepository>();
            services.AddTransient<IVnpReturnUrlLogRepository,VnpReturnUrlLogRepository>();
            services.AddTransient<IVnpIpnLogRepository,VnpIpnLogRepository>();
            #endregion
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITransactionService,TransactionService>();
            services.AddTransient<IAuthService,AuthService>();
            services.AddTransient<IRoleService, RoleService>();

        }
    }
}
