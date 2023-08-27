using student_department.Models;

namespace student_department.BLL
{
    public class StudentMoc:IStudent
    {
        static List<Student> student = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name="Ahmed",
                Age=25,
                Email="Ahmed@gmail.com",
                DeptId=1,
                 Departments= new Department() {Id=1,Name="cs"},
                 Password="ahmed123",
                 CPassword="ahmed123"
            },new Student()
            {
                Id = 2,
                Name="Mohemd",
                Age=26,
                Email="Mohamed@gmail.com",
                DeptId=2,
                 Departments= new Department() {Id=2,Name="it"},
                 Password="mohamed123",
                 CPassword="mohamed123"
            },new Student()
            {
                Id = 3,
                Name="Mahmod",
                Age=23,
                Email="mahmod@gmail.com",
                DeptId=3,
                 Departments= new Department() {Id=3,Name="hr"},
                 Password="mahmod123",
                 CPassword="1mahmod123"
            }
        };
        public List<Student> GetAll()
        { 
            return student; 
        }
        public Student GetById(int id)
        {
            return student?.FirstOrDefault(s => s.Id == id);
        }
        public void Update(Student s)
        {
            var s2 = GetById(s.Id);
            s.Departments = GetDept()?.Where(d => d.Id == s.DeptId).FirstOrDefault();
            student[s2.Id - 1] = s;
        }
        public void Delete(int id)
        {
            var x = GetById(id);
            student.Remove(x);
        }

        public void Add(Student std) 
        {
            std.Id=student.Count+1;
            std.Departments = GetDept()?.Where(d => d.Id == std.DeptId).FirstOrDefault();
            student.Add(std);
        }
        public List<Department>? GetDept()
        {
            var std= GetAll()?.Select(s => s.Departments)?.Distinct().ToList();
            //if(std == null)
            //{
            //    return new List<Department> { new Department() };
            //}
            return std;
        }
        public bool IsEmailExist(string email)
        {
            return student.Any(s => (s.Email ?? "").ToLower() == email.ToLower());
        }
        public bool IsEmailExist(string email, int id)
        {
            return student.Any(s => (s.Email ?? "").ToLower() == email.ToLower() && s.Id == id);
        }
    }
}
