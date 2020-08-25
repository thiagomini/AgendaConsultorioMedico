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
        public DateTimeOffset HoraConsultaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidDate]
        [LaterDate(nameof(HoraConsultaInicio))]
        public DateTimeOffset HoraConsultaFim { get; set; }

        [MaxLength(250)]
        public string Observacao { get; set; } 

        [PositiveNumber]
        [Required]
        public int PersonId { get; set; }
    }
}