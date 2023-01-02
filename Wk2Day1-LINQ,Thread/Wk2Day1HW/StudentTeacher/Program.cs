namespace StudentTeacher
{
    public class Program
    {
        class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public List<int> Scores;
        }

        class Teacher

        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public string City { get; set; }
        }

        static void Main(string[] args)
        {
            // Display the student name and the teacher name who live in the same city
            List<Student> students = new List<Student>
        {
            new Student
            {
                First = "John",
                Last = "Doe",
                ID = 12345,
                Street = "123 Main Street",
                City = "New York",
                Scores = new List<int> { 80, 90, 70 }
            },
            new Student
            {
                First = "Jane",
                Last = "Smith",
                ID = 67890,
                Street = "456 Park Avenue",
                City = "Chicago",
                Scores = new List<int> { 90, 60, 85 }
            },
            new Student
            {
                First = "Bob",
                Last = "Johnson",
                ID = 24679,
                Street = "789 Elm Street",
                City = "New York",
                Scores = new List<int> { 70, 80, 75 }
            }
        };





            List<Teacher> teachers = new List<Teacher>
        {
            new Teacher
            {
                First = "Alice",
                Last = "Brown",
                ID = 54321,
                City = "New York"
            },
            new Teacher
            {
                First = "Mike",
                Last = "Williams",
                ID = 98765,
                City = "Chicago"
            },
            new Teacher
            {
                First = "Sarah",
                Last = "Jones",
                ID = 56789,
                City = "New York"
            }
        };
           // a)	Using LINQ, display the student name and the teacher name who live in the same city

            var sameCity = from s in students
                           join t in teachers on s.City equals t.City
                           select new { Student = s.First + " " + s.Last, Teacher = t.First + " " + t.Last, City = s.City };

            Console.WriteLine("Students and teachers who live in the same city (query syntax):");
            foreach (var pair in sameCity)
            {
                Console.WriteLine($"{pair.Student} and {pair.Teacher} live in {pair.City}.");
            }
            Console.WriteLine();

            //b. Generate a list of objects, each object contains the student name and the teacher name who live in the same city and the city name is "New York"
            var sameCityNY = students.Join(teachers,
                                           s => s.City,
                                           t => t.City,
                                           (s, t) => new { Student = s.First + " " + s.Last, Teacher = t.First + " " + t.Last, City = s.City })
                                     .Where(pair => pair.City == "New York");

            Console.WriteLine("Students and teachers who live in the same city and the city name is \"New York\" (method syntax):");
            foreach (var pair in sameCityNY)
            {
                Console.WriteLine($"{pair.Student} and {pair.Teacher} live in {pair.City}.");
            }
        }
    }
}