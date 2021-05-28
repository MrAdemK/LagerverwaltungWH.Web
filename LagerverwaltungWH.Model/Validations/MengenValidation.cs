using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerverwaltungWH.Model.DatabaseModels;

namespace LagerverwaltungWH.Model.Validations
{
    public class MengenValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var menge = (Lagerartikel) validationContext.ObjectInstance;

            if (menge.Lagerstand >= 0)
                return ValidationResult.Success;
            return new ValidationResult("Lagerstand darf nicht in Minus");
        }
    }
}
