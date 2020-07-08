using System;
using System.ComponentModel.DataAnnotations;
using AgendaConsultorioMedico.Data.Annotations;

namespace AgendaConsultorioMedico.Dto
{
    public class AppointmentUpdateDto
    {
        [Required]
        [DataType(DataType.Date)]
        [ValidDate]
        public DateTime HoraConsultaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidDate]
        [LaterDate(nameof(HoraConsultaInicio))]
        public DateTime HoraConsultaFim { get; set; }

        [MaxLength(250)]
        public string Observacao { get; set; } 

        [Required]
        [PositiveNumber]
        public int PersonId { get; set; }
    }
}