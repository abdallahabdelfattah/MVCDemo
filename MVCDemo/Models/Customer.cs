using MVCDemo.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MVCDemo.Models
{
    public class Customer
    {
        //  Fluent APi 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        //[Required, MustBeA , MinLength(8,ErrorMessage ="عدد الحروف المسموح بها 8 حروف على الاقل ") ,MaxLength(50)]

       [DisplayName("الاسم الاول ")]
        [Required(ErrorMessage ="Required")]
  
        public string  FirstName { get; set; }

        [Required,MaxLength(10), DisplayName("Last Name")]
        //[MustBeA]
        public  string  LastName { get; set; }

        //[Required]
        public  Gender?  Gender { get; set; }  //  boolean      enum 
        public DateTime BirthDate { get; set; }

        public string?  ImagePath  { get; set; }
        public byte[]? Image { get; set; }

        [NotMapped]
        public IFormFile MyFile { get; set; }

        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public int CreatedBy { get; set; } = 1; 
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        //[Range(1,50)]
        public int? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language? Language { get; set; }


        public List<CustomerCourses>? Courses { get; set; }




    }



    public enum Gender
    {
        Male=1,
        Female=0
    }
}
