using System.Collections.Generic;
using System.Reflection;
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
            CreateMap<Person, PersonCreateDto>();
            CreateMap<PersonCreateDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
        }
    }
}