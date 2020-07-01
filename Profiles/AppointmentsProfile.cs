using AutoMapper;
using AgendaConsultorioMedico.Data;
using AgendaConsultorioMedico.Dto;

namespace AgendaConsultorioMedico.Profiles
{
    public class AppointmentsProfile : Profile
    {
       public AppointmentsProfile()
       {
           // Origem -> Alvo
            CreateMap<Appointment, AppointmentReadDto>();
            CreateMap<Appointment, AppointmentCreateDto>();
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<AppointmentUpdateDto, Appointment>();
       }
    }
}