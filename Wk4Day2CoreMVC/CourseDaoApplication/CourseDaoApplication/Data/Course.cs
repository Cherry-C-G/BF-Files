namespace CourseDaoApplication.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}