using System.ComponentModel.DataAnnotations;
namespace thewall.Models
{
    public class Message
    {
        [Required]
        public string message { get; set; }
    }
}