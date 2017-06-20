using System;
using System.ComponentModel.DataAnnotations;

namespace bankroll.Models
{
    public class Transactions : BaseEntity
    {
        [Key]
        public int transactionId { get; set; }
        public int action { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd yyyy}", ApplyFormatInEditMode = true)]
        public DateTime tcreatedAt { get; set; }
        public DateTime tupdatedAt { get; set; }
        public int userId { get; set; }

    }
}