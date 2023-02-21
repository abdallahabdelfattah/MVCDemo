using Microsoft.EntityFrameworkCore.Internal;

namespace MVCDemo.Services
{
    public interface IProductService
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }


    public class ScopedProduct2Service : IProductService
    {
        public ScopedProduct2Service()
        {
            this.Id = Guid.NewGuid(); 
            this.Time= DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }


    public class SingleToneProduct2Service : IProductService
    {
        public SingleToneProduct2Service()
        {
            this.Id = Guid.NewGuid();
            this.Time = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }


    public class transantProduct2Service : IProductService
    {
        public transantProduct2Service()
        {
            this.Id = Guid.NewGuid();
            this.Time = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }





}
