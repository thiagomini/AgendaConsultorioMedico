using AgendaConsultorioMedico.Data;
using AgendaConsultorioMedico.Dto;
using AutoMapper;

namespace AgendaConsultorioMedico.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            // Origem -> Alvo
            CreateMap<Person, PersonReadDto>();
        }
    }
}