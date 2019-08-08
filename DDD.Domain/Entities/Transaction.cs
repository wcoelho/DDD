namespace DDD.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public double Value { get; set; }
        public int CheckingAccountId { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; } 
    }
    
}