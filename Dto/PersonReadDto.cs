using System;
using System.Collections.Generic;

namespace AgendaConsultorioMedico.Dto
{
    public class PersonReadDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public List<AppointmentReadDto> Appointments { get; set; }
    }
}