using System;
using System.ComponentModel.DataAnnotations;
using AgendaConsultorioMedico.Data.Annotations;

namespace AgendaConsultorioMedico.Data
{
    public class Appointment : IComparable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidDate]
        public DateTimeOffset HoraConsultaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [LaterDate(nameof(HoraConsultaInicio))]
        [ValidDate]
        public DateTimeOffset HoraConsultaFim { get; set; }

        [MaxLength(250)]
        public string Observacao { get; set; } 

        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int CompareTo(object obj)
        {
            Appointment consulta = (Appointment) obj;
            return DateTimeOffset.Compare(this.HoraConsultaInicio, consulta.HoraConsultaInicio);
        }

        public Appointment(int id, DateTimeOffset horaConsultaInicio, DateTimeOffset horaConsultaFim, string observacao, int personId)
        {
            this.Id = Id;
            this.HoraConsultaInicio = horaConsultaInicio;
            this.HoraConsultaFim = horaConsultaFim;
            this.Observacao = observacao;
            this.PersonId = personId;
        }

        public Appointment()
        {

        }
    }
}