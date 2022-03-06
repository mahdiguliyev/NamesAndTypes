using NamesAndTypes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NamesAndTypes.Validations
{
    public class CheckSpecificWordsForType : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (AddViewModel)validationContext.ObjectInstance;

            if (model.Type == "george" || model.Type == "test")
                return new ValidationResult("The value of Type cannot be 'george' and 'test'");
            return ValidationResult.Success;
        }
    }
}
