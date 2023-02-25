using MVCDemo.Models;

namespace MVCDemo.Validation
{
    public class CustomerFilterVM
    {
        public string?  Search  { get; set; }
        public Gender? Gender { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

    }
}
