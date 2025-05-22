using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class EmployeeDto
    {
        
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Rfid { get; set; } = "";
        [Required, MaxLength(100)]
        public string Lastname { get; set; } = "";
        [Required, MaxLength(100)]
        public string Firstname { get; set; } = "";
        [Required, MaxLength(100)]
        public string Middlename { get; set; } = "";
        [Required, MaxLength(100)]
        public string Birthdate { get; set; } = "";
        public int Age { get; set; }
    }
}
