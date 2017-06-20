using System;
using System.ComponentModel.DataAnnotations;

namespace Restauranter.Models
{
    public class Reviews
    {
        [Required]
        [Key]
        public int ReviewsId { get; set; }

        [Required]
        public string Reviewer { get; set; }

        [Required]
        public string Restaurant { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CurrentDate(ErrorMessage = "Date must be after or equal to current date")]
        public DateTime VisitDate { get; set; }
        
        [Required]
        public int Stars { get; set; }

        public DateTime RCreatedAt { get; set; }

        public class CurrentDateAttribute : ValidationAttribute{
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }

    }
    
}