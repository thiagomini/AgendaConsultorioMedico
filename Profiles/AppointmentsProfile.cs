using AutoMapper;
using AgendaConsultorioMedico.Data;
using AgendaConsultorioMedico.Dto;

namespace AgendaConsultorioMedico.Profiles
{
    public class AppointmentsProfile : Profile
    {
       public AppointmentsProfile()
       {
            CreateMap<Appointment, AppointmentReadDto>();
       }
    }
}