using System;
using System.ComponentModel.DataAnnotations;
using AgendaConsultorioMedico.Data.Annotations;

namespace AgendaConsultorioMedico.Dto
{
    public class AppointmentCreateDto
    {
        [Required]
        [DataType(DataType.Date)]
        [ValidDate]
        public DateTime HoraConsultaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidDate]
        public DateTime HoraConsultaFim { get; set; }

        [MaxLength(250)]
        public string Observacao { get; set; } 

        [PositiveNumber]
        [Required]
        public int PersonId { get; set; }
    }
}