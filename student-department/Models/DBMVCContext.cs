using Microsoft.EntityFrameworkCore;

namespace student_department.Models
{
    public class DBMVCContext:DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DBMVC;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Departments)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DeptId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
