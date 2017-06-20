using System.ComponentModel.DataAnnotations;
namespace thewall.Models
{
    public class Comment
    {
        [Required]
        public string comment { get; set; }
    }
}