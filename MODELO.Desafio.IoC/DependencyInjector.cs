using AutoMapper;
using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.DAL.Interface.Loaders;
using MODELO.Desafio.DAL.Loaders;
using MODELO.Desafio.Model.Request;
using MODELO.Desafio.Model.Result;
using MODELO.Desafio.Model.Validators;
using MODELO.Desafio.Service.Interface.Providers;
using MODELO.Desafio.Service.Interface.Updaters;
using MODELO.Desafio.Service.Providers;
using MODELO.Desafio.Service.Updaters;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace MODELO.Desafio.IoC
{
    [ExcludeFromCodeCoverageAttribute] 
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            RegisterLogin(services);
        }

        public static void RegisterLogin(IServiceCollection services)
        {
            RegisterUpdaters(services);
            RegisterProviders(services);
            RegisterServices(services);
            RegisterValidators(services);
        }
        private static void RegisterValidators(IServiceCollection services)
        {
            services.TryAddTransient<IValidator<FairRequest>, FairRequestValidator >();
            services.AddSingleton(typeof(FairRequestValidator));

        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.TryAddScoped<IEqualizeDatabase, EqualizeDatabase>();
        }

        
        private static void RegisterProviders(IServiceCollection services)
        {
            services.TryAddScoped<IFairProvider, FairProvider>();
        }

        private static void RegisterUpdaters(IServiceCollection services)
        {

            services.TryAddScoped<IFairUpdater, FairUpdater>();


            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<FairRequest, Fair>();
                config.CreateMap<FairResult, Fair>();
                config.CreateMap<Fair, FairResult>();
                config.CreateMap<Fair, FairRequest>();
            }).CreateMapper());

        }
    }
}
