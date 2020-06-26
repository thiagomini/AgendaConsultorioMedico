using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaConsultorioMedico.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime HoraConsultaInicio { get; set; }

        [Required]
        public DateTime HoraConsultaFim { get; set; }

        [MaxLength(250)]
        public string Observacao { get; set; } 

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}