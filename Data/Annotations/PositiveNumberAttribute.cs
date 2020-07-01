using System.ComponentModel.DataAnnotations;

namespace AgendaConsultorioMedico.Data.Annotations
{
    public class PositiveNumberAttribute : ValidationAttribute
    {
        public PositiveNumberAttribute()
        {
            this.ErrorMessage = "Must be a valid positive Integer!";
        }

        public override bool IsValid(object value)
        {
            int intValue = (int) value;

            return intValue > 0;
        }
    }
}