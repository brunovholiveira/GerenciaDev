using AutoMapper;
using GDev.Business.Model;
using GDev.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDev.WebApp.Automapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Acesso, AcessoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Modulo, ModuloViewModel>()
                //.ForMember(dest => dest.DiaAlteracao, options => options.MapFrom(moduloitem => moduloitem.DiaAlteracao == null ?  null : moduloitem.DiaAlteracao))
                .ReverseMap();
        }
    }
}
