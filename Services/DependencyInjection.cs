using Microsoft.EntityFrameworkCore;
using MiniKFCStore.Repositories.Interface;
using MiniKFCStore.Repositories.Repository;
using MiniKFCStore.Repositories;
using MiniKFCStore.Services.Interface;
using MiniKFCStore.Services.Service;

namespace MiniKFCStore.Services
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories and services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
