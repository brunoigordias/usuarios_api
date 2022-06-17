using Business.Interfaces;
using Business.Services;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;

namespace API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiContext>();
            
            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
            services.AddScoped<IHistoricoEscolarRepository, HistoricoEscolarRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
            services.AddScoped<IEscolaridadeService,EscolaridadeService>();
            services.AddScoped<IHistoricoEscolarService,HistoricoEscolarService>();
            services.AddScoped<IUsuarioService,UsuarioService>();

            return services;
        }
    }
}
