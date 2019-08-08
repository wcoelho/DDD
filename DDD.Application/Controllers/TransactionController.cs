using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DDD.Domain.Entities;
using DDD.Service.Services;
using DDD.Service.Validators;

namespace DDD.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private BaseService<Transaction> serviceTransaction = new BaseService<Transaction>();
        private BaseService<CheckingAccount> serviceCheck = new BaseService<CheckingAccount>();
        private BaseService<User> serviceUser = new BaseService<User>();

        ILogger _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Transaction transaction)
        {
            try
            {
                CheckingAccount checkingAccount = serviceCheck.Get(transaction.CheckingAccountId);

                if(checkingAccount==null){
                    return NotFound("Conta corrente não encontrada");
                }

                if(!validateTransaction(checkingAccount,transaction)){
                    return BadRequest("Você não tem saldo suficiente");
                }

                var newAmount = checkingAccount.Amount + transaction.Value;
                checkingAccount.Amount = newAmount;

                serviceTransaction.Post<TransactionValidator>(transaction);
                serviceCheck.Put<CheckingAccountValidator>(checkingAccount);

                return new ObjectResult("Novo saldo = " + newAmount);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(serviceTransaction.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private Boolean validateTransaction(CheckingAccount checkingAccount, Transaction transaction)
        {

                double amount = checkingAccount.Amount;
                double limit = checkingAccount.Limit;
                double value = transaction.Value;

                Boolean result = !(value<0 && (amount+limit+value)<0);

                if(result && value < 0 && value < -50000)
                    sendMessageToCoaf(checkingAccount);

                return result;
                
        }

        private void sendMessageToCoaf(CheckingAccount checkingAccount)
        {            
            string userCpf = serviceUser.Get(checkingAccount.UserId).Cpf;
            _logger.LogInformation("Transação acima de R$ 50.000,00 feita pelo correntista com CPF " + userCpf);
        }
        
    }
}