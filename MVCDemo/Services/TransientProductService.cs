using Microsoft.EntityFrameworkCore.Internal;
using MVCDemo.Models;

namespace MVCDemo.Services
{
    public class ScopedProductService : IScopedProductService
    {

        public ScopedProductService()
        {
            this.Id = Guid.NewGuid(); 
            this.Time= DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }


    public class SingleToneProductService : ISingleToneProductService
    {

      
        public SingleToneProductService()
        {
            this.Id = Guid.NewGuid();
            this.Time = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }


    public class transantProductService : ItransantProductService
    {


        public transantProductService(ApplicationContext applicationContext)
        {
            //applicationContext.ContextId;
        }

        public transantProductService()
        {
            this.Id = Guid.NewGuid();
            this.Time = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }





}
