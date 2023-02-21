namespace MVCDemo.Models
{
    public class Course
    {

        public int CourseId { get; set; }
        public string Title { get; set; }
        public List<CustomerCourses>? Courses { get; set; }

    }
}
