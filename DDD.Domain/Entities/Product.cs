namespace DDD.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Code { get; set; }
        public double Price { get; set; } 
        public string SKU { get; set; } 
        
    }
    
}