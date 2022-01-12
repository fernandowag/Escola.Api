using AutoMapper;
using Escola.Api.DataTransferObjects;
using Escola.Api.Models;

namespace Escola.Api.Mappers
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            this.SetupInbound();
            this.SetupOutbound();
        }

        public void SetupInbound()
        {
            this.CreateMap<AlunoRequest, Aluno>();
        }

        public void SetupOutbound()
        {
            this.CreateMap<Aluno, AlunoResponse>()
                .ForMember(dest => dest.Aprovado, config => config.MapFrom( src => src.NotaGeral < 8 ? false : true ));
        }
    }
}
