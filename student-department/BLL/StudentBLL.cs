using Microsoft.EntityFrameworkCore;
using student_department.Models;

namespace student_department.BLL
{
    public class StudentBLL : IStudent
    {
        DBMVCContext context = new DBMVCContext();
        public List<Student> GetAll()
        {
            return context.Students.Include(x => x.Departments).ToList();
        }
        public Student GetById(int id)
        {
            return context.Students.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
        }
        public void Update(Student std)
        {
            context.Students.Update(std);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var std = context.Students.Where(x => x.Id == id).FirstOrDefault();
            context.Students.Remove(std);
            context.SaveChanges();
        }
        public List<Department>? GetDept()
        {
            var std =  context.Departments.ToList();
            return std;
        }
        public bool IsEmailExist(string email)
        {
            return context.Students.Any(s => (s.Email ?? "").ToLower() == email.ToLower());
        }
        public bool IsEmailExist(string email, int id)
        {
            return context.Students.Any(s => (s.Email ?? "").ToLower() == email.ToLower() && s.Id == id);
        }
    }
}
