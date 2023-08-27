using student_department.Models;

namespace student_department.BLL
{
    public class DepartmentBLL
    {
        DBMVCContext context = new DBMVCContext();
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(s => s.Id == id);
        }
        public void Add(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }
        public void Update(Department department)
        {
            var std = context.Departments.FirstOrDefault(s => s.Id == department.Id);
            std.Name = department.Name;
            context.SaveChanges();
        }
        public void Delete(int? id)
        {
            var std = context.Departments.FirstOrDefault(s => s.Id == id.Value);
            context.Departments.Remove(std);
            context.SaveChanges();
        }
    }
}
