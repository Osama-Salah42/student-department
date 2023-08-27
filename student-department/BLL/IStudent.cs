using student_department.Models;

namespace student_department.BLL
{
    public interface IStudent
    {
            public List<Student> GetAll();
            public Student GetById(int id);
            public void Update(Student std);
            public void Add(Student std);
            public void Delete(int id);
            public List<Department>? GetDept();
            public bool IsEmailExist(string email);
            public bool IsEmailExist(string email, int id);
    }
}
