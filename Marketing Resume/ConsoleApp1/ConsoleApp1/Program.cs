public class MyDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>

          (entity => entity.ToTable("Student");
        entity.Property(s => s.Name)
       .HasKey(s => s.ID)
       .IsRequired()
       .HasMaxLength(50));

        modelBuilder.Entity<Course>

  (entity => entity.ToTable("Courses");
        entity.Property(c => c.Name)
       .HasKey(c => c.ID)
       .IsRequired()
       .HasMaxLength(50));

        modelBuilder.Entity<StudentCourse>

(entity => entity.ToTable("StudentCourses");
        .HasMany(c => c.Students)
           .WithMany(s => s.Courses)
           .Map(m =>
           {
               m.ToTable("StudentCourses");
               m.MapLeftKey("CourseID");
               m.MapRightKey("StudentID");
           });

        modelBuilder.Entity<StudentCourse>()
.HasOne(sc => sc.Student)
.WithMany(s => s.StudentCourse)
.HasForeignKey(sc => sc.StudentID);

        modelBuilder.Entity<StudentCourse>()
.HasOne(sc => sc.Course)
.WithMany(c => c.StudentCourse)
.HasForeignKey(sc => sc.CourseID);
    }
}
