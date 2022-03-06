using NamesAndTypes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NamesAndTypes.Validations
{
    public class CheckSpecificWordsForName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (AddViewModel)validationContext.ObjectInstance;

            if (model.Name == "george" || model.Name == "test")
                return new ValidationResult("The value of Name cannot be 'george' and 'test'");
            return ValidationResult.Success;
        }
    }
}
