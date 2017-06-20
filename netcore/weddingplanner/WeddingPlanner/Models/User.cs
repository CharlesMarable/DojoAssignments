using System.Collections.Generic;

namespace WeddingPlanner.Models{
    public class User: BaseEntity{
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        List<Guest> Guests { get; set; }

        public User(){
            Guests = new List<Guest>();
        }
    }
}