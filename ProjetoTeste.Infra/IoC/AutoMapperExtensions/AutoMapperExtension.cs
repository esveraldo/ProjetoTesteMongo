using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Infra.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.IoC.AutoMapperExtensions
{
    public static class AutoMapperExtension
    {
        public static void AddRegisterAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            services.AddSingleton(c => mapper.CreateMapper());
        }
    }
}
