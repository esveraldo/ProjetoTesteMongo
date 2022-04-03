using AutoMapper;
using MongoDB.Bson;
using ProjetoTeste.Application.Dto;
using ProjetoTeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest =>dest.Id, source => source.MapFrom(x => x.Id.ToString()));

            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.Id, source => source.MapFrom(x => ObjectId.Parse(x.Id)));

            CreateMap<Produto, ProdutoRequestDto>().ReverseMap();
        }
    }
}
