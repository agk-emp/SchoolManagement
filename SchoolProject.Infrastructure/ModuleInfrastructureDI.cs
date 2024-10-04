using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Repositories;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDIS(this IServiceCollection services,
            IConfigurationManager configuration)
        {
            services.AddDbContextFactory<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("dbcontext"));
            });
            services.AddTransient(typeof(IGenericRepository<>),
                typeof(GenericRepository<>));
            services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
