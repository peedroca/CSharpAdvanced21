using apiwithpomelo.Entities;
using apiwithpomelo.Repositories;
using apiwithpomelo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace apiwithpomelo
{
    internal static class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<mysql_17753_devmonkContext>();           
            services.AddScoped<IRepository<TbCliente>, ClienteRepository>();
            
            services.AddScoped<ClienteService>();
        }
    }
}