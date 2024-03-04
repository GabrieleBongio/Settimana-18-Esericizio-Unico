using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Settimana_18_Esericizio_Unico.CustomValidations
{
    public class CustomCheckIfOnlyNumbers : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            foreach (char c in value.ToString())
            {
                if (!"1234567890".Contains(c))
                {
                    return new ValidationResult(
                        "Questo campo deve contenere una serie di soli numeri"
                    );
                }
            }

            return ValidationResult.Success;
        }
    }
}
