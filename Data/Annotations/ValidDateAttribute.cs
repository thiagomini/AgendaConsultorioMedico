using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaConsultorioMedico.Data.Annotations
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public ValidDateAttribute()
        {
            this.ErrorMessage = "Must be a valid Date!";
        }

        public override bool IsValid(object value)
        {
            DateTimeOffset dateValue = DateTimeOffset.Parse(value.ToString());
            return dateValue != new DateTimeOffset();
        }
    }
}