using System;
using System.Text.Json.Serialization;

namespace task1.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
