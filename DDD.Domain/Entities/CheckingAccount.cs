using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.Collections.Generic;

namespace DDD.Domain.Entities
{
    public class CheckingAccount : BaseEntity
    {
        public CheckingAccount (){
            Transactions = new HashSet<Transaction>();
        }
        public double Amount { get; set; }
        public double Limit { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public int UserId { get; set; } 
        public virtual User User { get; set;}
    }
}