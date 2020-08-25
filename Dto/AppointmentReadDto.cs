using System;

namespace AgendaConsultorioMedico.Dto
{
    public class AppointmentReadDto
    {

        public int Id { get; set; }

        public DateTimeOffset HoraConsultaInicio { get; set; }

        public DateTimeOffset HoraConsultaFim { get; set; }

        public string Observacao { get; set; } 

        public int PersonId { get; set; }

        public PersonReadDto Person { get; set; }
    }
}