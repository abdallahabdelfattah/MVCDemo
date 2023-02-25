using MVCDemo.Validation;

namespace MVCDemo.ViewModels
{
    public class ResponcesDto
    {
        public List<CustomerVM> Customers { get; set; }


        //  Binding 
        public CustomerFilterVM  Filter  { get; set; }

    }
}
