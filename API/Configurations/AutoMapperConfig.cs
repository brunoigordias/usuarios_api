using API.ViewModels;
using Business.DTOs;
using Business.Models;

namespace API.Configurations
{
    public class AutoMapperConfig : AutoMapper.Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioCreateDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateViewModel>().ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.Escolaridade, opt => opt.MapFrom(src => src.Escolaridade.Descricao))
                .ForMember(dest => dest.HistoricoEscolar, opt => opt.MapFrom(src => src.HistoricoEscolar.Nome));

            CreateMap<Escolaridade,EscolaridadeViewModel>().ReverseMap();

            CreateMap<HistoricoEscolar, HistoricoEscolarViewModel>().ReverseMap();

            CreateMap< IFormFile, HistoricoEscolar >()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Formato, opt => opt.MapFrom(src => src.ContentType));


        }
    }
}
