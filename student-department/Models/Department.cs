namespace student_department.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public Department()
        {
            Students = new HashSet<Student>();
        }
    }
}
