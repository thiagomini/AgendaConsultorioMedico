using System.Collections.Generic;

namespace AgendaConsultorioMedico.Data
{
    public interface IAppointmentsRepository
    {
        bool SaveChanges();

        IEnumerable<Appointment> GetAllAppointments();

        Appointment GetAppointmentById(int id);

        void CreateAppointment(Appointment newAppointment, bool save=true);

        void UpdateAppointment(Appointment updatedAppointment, bool save=true);

        void DeleteAppointment(Appointment targetAppointment, bool save=true);
    }
}