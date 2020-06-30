using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaConsultorioMedico.Dto
{
    public class PersonCreateDto
    {
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; set; }
    }
}