using MVCDemo.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MVCDemo.Validation;

namespace MVCDemo.ViewModels
{
    public class CustomerVM
    {
  
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [Required, MaxLength(10), DisplayName("Last Name")]
        public string LastName { get; set; }

        public Gender? Gender { get; set; }  //  boolean      enum 
        public DateTime BirthDate { get; set; }

        public string? ImagePath { get; set; }
      
        public string Base64Image { get; set; }

        public DateTime CreatedDate { get; set; }

        

    }


    //public CustomerFilterVM Filter  { get; set; } 


}
