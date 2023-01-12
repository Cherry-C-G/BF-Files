using CourseDaoApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CourseDaoApplication
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student_Course> StudentCourses { get; set; }

    }

}