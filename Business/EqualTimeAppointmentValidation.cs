using System;
using System.Collections.Generic;
using AgendaConsultorioMedico.Data;

namespace AgendaConsultorioMedico.Business
{
    public class EqualTimeAppointmentValidation : IAppointmentValidation
    {
        public bool CanAddAppointment(Appointment appointment, List<Appointment> allAppointments)
        {
            allAppointments.Add(appointment);
            allAppointments.Sort();

            // Ordena a lista de consultas pela Data de Início
            int newAppointmentPosition = allAppointments.IndexOf(appointment);

            var nextAppointment = allAppointments.Count == newAppointmentPosition-1
                ? allAppointments[newAppointmentPosition + 1]
                : null ;

            var previousAppointment = newAppointmentPosition == 0
                ? null
                : allAppointments[newAppointmentPosition - 1];

            return IsLaterThanPrevious(appointment, previousAppointment) && IsEarlierThanNext(appointment, nextAppointment);

        }

        /*
            Verifica se a currentAppointment começa depois da previousAppointment
        */
        private bool IsLaterThanPrevious(Appointment currentAppointment, Appointment previousAppointment)
        {
            if (previousAppointment == null)
            {
                return true;
            }
            return currentAppointment.HoraConsultaInicio >= previousAppointment.HoraConsultaFim;
        }

        private bool IsEarlierThanNext(Appointment currentAppointment, Appointment nextAppointment)
        {
            if (nextAppointment == null)
            {
                return true;
            }
            return currentAppointment.HoraConsultaFim <= nextAppointment.HoraConsultaInicio;
        }
    }
}