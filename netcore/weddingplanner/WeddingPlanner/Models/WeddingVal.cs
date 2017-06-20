using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
    public class WeddingVal: BaseEntity{
        [Required]
        [MinLength(2)]
        public string WedderOne { get; set; }

        [Required]
        [MinLength(2)]
        public string WedderTwo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CurrentDate(ErrorMessage = "Date must be future date")]
        public DateTime WDate { get; set; }

        [Required]
        public string Address { get; set; }

        public class CurrentDateAttribute : ValidationAttribute{
            public CurrentDateAttribute(){

            }

            public override bool IsValid(object value)
            {
                var dt = (DateTime)value;
                if(dt >= DateTime.Now)
                    {
                        return true;
                    }
                return false;
            }
        }   
    }
}