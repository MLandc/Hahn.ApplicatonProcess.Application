using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using Hahn.ApplicatonProcess.December2020.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.December2020.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HahnApplicationProcessDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HahnApplicatonProcessConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IApplicantRepository, ApplicantRepository>();
           
            return services;
        }
    }
}
