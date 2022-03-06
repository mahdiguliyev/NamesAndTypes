using NamesAndTypes.Validations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NamesAndTypes.Models
{
    public class AddViewModel
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(32, ErrorMessage = "{0} lenght cannot be more than {1}.")]
        [MinLength(4, ErrorMessage = "{0} lenght cannot be less than {1}.")]
        [CheckSpecificWordsForName]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9._-]{3,32}$", ErrorMessage = "{0} characters can contain: English letters plus: (0,1,2,3,4,6,7,8,9), _, -,.")]
        public string Name { get; set; }
        [DisplayName("Type")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(32, ErrorMessage = "{0} lenght cannot be more than {1}.")]
        [MinLength(4, ErrorMessage = "{0} lenght cannot be less than {1}.")]
        [CheckSpecificWordsForType]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9._-]{3,32}$", ErrorMessage = "{0} characters can contain: English letters plus: (0,1,2,3,4,6,7,8,9), _, -,.")]
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
