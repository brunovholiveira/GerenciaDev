using AutoMapper;
using GDev.Business.Model;
using GDev.API.ViewModels;

namespace GDev.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Modulo, ModuloViewModel>().ReverseMap();
            CreateMap<Acesso, AcessoViewModel>().ReverseMap();
        }
    }
}
