using System.ComponentModel.DataAnnotations;
namespace logandreg.Models
{
    public class User
    {
        [Required]
        [MinLength(1)]
        public string fname { get; set; }

        [Required]
        [MinLength(1)]
        public string lname { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}