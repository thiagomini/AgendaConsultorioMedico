using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaConsultorioMedico.Data.Annotations
{
    //
    // Summary:
    //      Especifica que um campo Data deve ser maior que outro campo Data.w
    public class LaterDateAttribute : CompareAttribute
    {
        private readonly string _otherProperty;

        //
        // Summary:
        //      Inicia uma instância de LaterDateAttribute,
        //      que compara se essa propriedade do tipo Date é maior que a outra propriedade especificada
        public LaterDateAttribute(string otherProperty) : base(otherProperty)
        {
            this._otherProperty = otherProperty;
            this.ErrorMessage = "Deve ser uma data posterior à " + (this._otherProperty);  
        }

        //
        // Summary:
        //    Verifica se um campo Data é maior que outro campo Data.
        //
        // Parameters:
        //   value:
        //     O atributo a ser comparado com a outra propriedade.
        //
        // Returns:
        //     verdadeiro se a data do atributo decorado é maior que a data da propriedade comparada. 
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     O tipo do value passado como parâmetro não é DateTime.    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this._otherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult(string.Format("propriedade inexistente {0}", this._otherProperty));
            }

            var propertyTestedValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is DateTimeOffset))
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || !(propertyTestedValue is DateTimeOffset))
            {
                return ValidationResult.Success;
            }

            DateTimeOffset dateValue = DateTimeOffset.Parse(value.ToString());
            DateTimeOffset otherDate = DateTimeOffset.Parse(propertyTestedValue.ToString());

            if (dateValue > otherDate)
            {
                return ValidationResult.Success;
            }
            else 
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            
        }
    }
}