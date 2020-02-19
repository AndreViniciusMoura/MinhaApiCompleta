using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MinhaApiCompleta.Api.Extensions;
using MinhaApiCompleta.Business.Intefaces;
using MinhaApiCompleta.Business.Intefaces.Repositories;
using MinhaApiCompleta.Business.Intefaces.Services;
using MinhaApiCompleta.Business.Notificacoes;
using MinhaApiCompleta.Business.Services;
using MinhaApiCompleta.Data.Context;
using MinhaApiCompleta.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;

namespace MinhaApiCompleta.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            #region Services

            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IUserService, AspNetUser>();


            #endregion

            #region Repository

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            #endregion

            return services;
        }
    }
}
