using System.ComponentModel.DataAnnotations;

namespace WebApplication11_MVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}