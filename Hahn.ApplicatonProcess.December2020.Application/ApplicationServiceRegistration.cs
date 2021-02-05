using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hahn.ApplicatonProcess.December2020.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationSerices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
