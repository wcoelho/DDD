using System;
using Xunit;
using DDD.Infra.Data.Repository;
using DDD.Domain.Interfaces;
using DDD.Domain.Entities;
using DDD.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DDD.Service.Validators;
using FluentValidation;

namespace DDD.Tests
{
    public class CheckTransaction
    {
      	[Theory]
        [InlineData(-20000.0, 40000.0, 50000.0)]//Debit
        [InlineData(10000.0, 30000.0, 50000.0)]//Credit
        [InlineData(-60000.0, 5000.0, 50000.0)]//Debit denied
        public void CanCreateAndSave(double value, double amount, double limit)
        {
            TestService<Transaction> service = new TestService<Transaction>();
            TestService<CheckingAccount> serviceCheck = new TestService<CheckingAccount>();

            var chkAccount = new CheckingAccount();
            Assert.NotNull(chkAccount);
            chkAccount.Amount = amount;
            chkAccount.Limit = limit; 

            var res = serviceCheck.Post<CheckingAccountValidator>(chkAccount);
            Assert.True(chkAccount.Id>-1);            

            var transct = new Transaction();
            Assert.NotNull(transct);
            transct.CheckingAccountId = chkAccount.Id;
            transct.Value = value;            

            service.Post<TransactionValidator>(transct);
            Assert.True(transct.Id>-1);
            
            var transct2 = service.Get(transct.Id);
            Assert.NotNull(transct2);       
            var chkAccount2 = serviceCheck.Get(chkAccount.Id);
            Assert.NotNull(chkAccount2);

            Assert.Equal(transct2.CheckingAccountId, chkAccount2.Id);
            Assert.Equal(transct2.CheckingAccountId, transct.CheckingAccountId);
            Assert.Equal(transct2.Value, transct.Value);

            Boolean result = !(value<0 && (amount+limit+value)<0);

            // Debit Denied
            if(!result)
                Assert.Equal(amount, chkAccount2.Amount);
            else
                Assert.Equal(amount+value, chkAccount2.Amount);
         
            var id = transct.Id;
            service.Delete(transct.Id);

            // Tentando deletar novamente e verificando se Exception é gerada.
            Assert.Throws<System.ArgumentNullException>(() => service.Delete(id));
        }

    }
}