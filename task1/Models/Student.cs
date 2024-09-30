namespace task1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
