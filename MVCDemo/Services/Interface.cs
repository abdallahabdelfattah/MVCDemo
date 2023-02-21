namespace MVCDemo.Services
{
    public interface IScopedProductService
    {
        public Guid Id { get; set; }
        public DateTime Time  { get; set; }

    }

    public interface ISingleToneProductService
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }

    public interface ItransantProductService
    {

     
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

    }

}
