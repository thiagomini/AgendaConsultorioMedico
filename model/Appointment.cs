using System;
using System.ComponentModel.DataAnnotations;
using AgendaConsultorioMedico.Data.Annotations;

namespace AgendaConsultorioMedico.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

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

        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}