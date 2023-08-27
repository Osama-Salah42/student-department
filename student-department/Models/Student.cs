using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student_department.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(10, 30)]
        public int? Age { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Remote(action: "checkEmail", controller: "Student", AdditionalFields = "Id", ErrorMessage = "Email already Exists!")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(3)]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }
        public int? DeptId { get; set; }
        public Department? Departments { get; set; }
    }
}
