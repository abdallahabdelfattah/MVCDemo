using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class CustomerCourses
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
