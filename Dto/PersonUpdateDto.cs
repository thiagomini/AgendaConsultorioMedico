using System;

namespace AgendaConsultorioMedico.Dto
{
    public class PersonUpdateDto
    {
         public string Nome { get; set; }
         public DateTimeOffset DataDeNascimento { get; set; }
    }
}