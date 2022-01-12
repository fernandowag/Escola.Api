using AutoMapper;
using Escola.Api.DataTransferObjects;
using Escola.Api.Models;

namespace Escola.Api.Mappers
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            this.SetupInbound();
            this.SetupOutbound();
        }

        public void SetupInbound()
        {
            this.CreateMap<TurmaRequest, Turma>();
        }

        public void SetupOutbound()
        {
            this.CreateMap<Turma, TurmaResponse>();
        }
    }
}
