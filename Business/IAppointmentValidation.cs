using System.Collections.Generic;
using AgendaConsultorioMedico.Data;

namespace AgendaConsultorioMedico.Business
{
    public interface IAppointmentValidation
    {
        bool CanAddAppointment(Appointment appointment, List<Appointment> allAppointments);
    }
}