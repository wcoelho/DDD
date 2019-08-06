using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Domain.Entities
{
    public class CheckingAccount : BaseEntity
    {
        public double Amount { get; set; }
        public double Limit { get; set; }        
        public int UserId { get; set; }
        public virtual User User { get; set;}
    }
}