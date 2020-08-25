using System;
using System.Collections.Generic;

namespace AgendaConsultorioMedico.Dto
{
    public class PersonReadDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTimeOffset DataDeNascimento { get; set; }

    }
}