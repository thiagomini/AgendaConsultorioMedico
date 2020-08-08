using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AgendaConsultorioMedico.Data
{
    public class SqlAppointmentsRepository : IAppointmentsRepository
    {
        private readonly AgendaDBContext _context;

        public SqlAppointmentsRepository(AgendaDBContext context)
        {
            _context = context;
        }

        public void CreateAppointment(Appointment newAppointment, bool save = true)
        {
            if (newAppointment == null) 
            {
                throw new ArgumentNullException(nameof(newAppointment));
            }

            _context.Appointments.Add(newAppointment);

            if (save) SaveChanges();
        }

        public void DeleteAppointment(Appointment targetAppointment, bool save = true)
        {
            if (targetAppointment == null)
            {
                throw new ArgumentNullException(nameof(targetAppointment));
            }

            _context.Appointments.Remove(targetAppointment);

            // Salva automaticamente
            if(save) SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
             return _context.Appointments
                .Include(appointment => appointment.Person)
                .ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(appointment => appointment.Id == id);
        }

        public bool SaveChanges()
        {
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public void UpdateAppointment(Appointment updatedAppointment, bool save = true)
        {
            // Sem implementação necessária ainda
            if (save) SaveChanges();
        }
    }
}