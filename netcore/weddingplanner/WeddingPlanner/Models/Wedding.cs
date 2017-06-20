using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace WeddingPlanner.Models{
    public class Wedding: BaseEntity{
        public int WeddingId { get; set; }

        [ForeignKey("User")]
        public User Creator { get; set; }
        public string WedderOne { get; set; }
        public string WedderTwo { get; set; }
        public DateTime WDate { get; set; }
        public string Address { get; set; }
        public List<Guest> Guests { get; set; }

        public Wedding(){
            Guests = new List<Guest>();
        }
    }
}