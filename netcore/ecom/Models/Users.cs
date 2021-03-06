using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class Users : BaseEntity
    {
        [Key]
        public int userId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime ucreatedAt { get; set; }
        public DateTime uupdatedAt { get; set; }

    }
}
