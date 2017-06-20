using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Login : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}