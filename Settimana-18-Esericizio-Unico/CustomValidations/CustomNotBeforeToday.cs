using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Settimana_18_Esericizio_Unico.CustomValidations
{
    public class CustomNotBeforeToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            DateTime currentdate = DateTime.Now;

            if (Convert.ToDateTime(value) < currentdate)
            {
                return new ValidationResult("La data deve essere antecedente a quella odierna");
            }

            return ValidationResult.Success;
        }
    }
}
