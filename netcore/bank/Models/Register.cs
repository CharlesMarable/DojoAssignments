using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Register    : BaseEntity
    {
        [Required]
        [MinLengthAttribute(2)]
        [RegularExpressionAttribute(@"^[a-zA-Z]+$")]
        public string firstname { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        [RegularExpressionAttribute(@"^[a-zA-Z]+$")]
        public string lastname { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLengthAttribute(8)]
        [DataTypeAttribute(DataType.Password)]
        public string password { get; set; }

        [CompareAttribute("password", ErrorMessage = "Password and confirmation must match.")]
        public string passwordConf { get; set; }
    }
    
}