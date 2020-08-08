using System;

namespace AgendaConsultorioMedico.Dto
{
    public class AppointmentReadDto
    {

        public int Id { get; set; }

        public DateTime HoraConsultaInicio { get; set; }

        public DateTime HoraConsultaFim { get; set; }

        public string Observacao { get; set; } 

        public int PersonId { get; set; }

        public PersonReadDto Person { get; set; }
    }
}