using System;

namespace DDD.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        private DateTime _BirthDate;
        public DateTime BirthDate { 
            get {
                return this._BirthDate;
            }
            set {
                if (CheckMajority(value)) {
                    this._BirthDate =  value;
                } else {
                    throw new Exception("Usuário menor de idade!");
                }
            }
        }
        public bool CheckMajority (DateTime? nascimento = null) {
            DateTime compare = (nascimento == null) ? this._BirthDate : nascimento ?? default(DateTime);
            if (((DateTime.Now - compare).TotalDays / 365.25) > 18) {
            	return true;
            }
        	return false;
        }
    }
}