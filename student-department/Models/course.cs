using Microsoft.Build.Framework;
namespace student_department.Models  
{
    public class course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
