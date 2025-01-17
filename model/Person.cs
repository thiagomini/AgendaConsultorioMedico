using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaConsultorioMedico.Data
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset DataDeNascimento { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}