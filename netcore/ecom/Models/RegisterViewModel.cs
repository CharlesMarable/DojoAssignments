using System.ComponentModel.DataAnnotations;
namespace ecom.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string firstname { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string lastname { get; set; }
 
        [Required]
        [EmailAddress]
        public string email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }
 
        [Compare("password", ErrorMessage = "Password and confirmation must match.")]
        public string passwordconf { get; set; }
    }
}