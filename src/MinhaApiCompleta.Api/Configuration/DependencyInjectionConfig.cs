﻿using Microsoft.Extensions.DependencyInjection;
using MinhaApiCompleta.Business.Intefaces;
using MinhaApiCompleta.Business.Intefaces.Repositories;
using MinhaApiCompleta.Business.Intefaces.Services;
using MinhaApiCompleta.Business.Notificacoes;
using MinhaApiCompleta.Business.Services;
using MinhaApiCompleta.Data.Context;
using MinhaApiCompleta.Data.Repository;

namespace MinhaApiCompleta.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<INotificador, Notificador>();

            #region Services

            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();            

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