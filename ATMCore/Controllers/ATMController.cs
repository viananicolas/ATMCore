using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMCore.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMCore.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ATMController : ControllerBase
    {
        private static readonly decimal[] BankNotes = {
           10m, 20m, 50m
        };
        [HttpPost]
        public IActionResult PostWithdrawal([FromBody] WithdrawalRequest withdrawalRequest)
        {
            return Ok(CheckBankNotes(withdrawalRequest));
        }

        private static Withdrawal CheckBankNotes(WithdrawalRequest withdrawalRequest)
        {
            var withdrawal = new Withdrawal();
            var withdrawalAmount = withdrawalRequest.Amount;
            while (withdrawalAmount >= BankNotes[2])
            {
                withdrawalAmount -= BankNotes[2];
                withdrawal.FiftyReaisAmount++;
            }
            while (withdrawalAmount >= BankNotes[1])
            {
                withdrawalAmount -= BankNotes[1];
                withdrawal.TwentyReaisAmount++;
            }
            while (withdrawalAmount >= BankNotes[0])
            {
                withdrawalAmount -= BankNotes[0];
                withdrawal.TenReaisAmount++;
            }
            if (withdrawalAmount != 0)
                withdrawal.Message = "Valor inválido. Sacando o valor mais próximo...";
            return withdrawal;
        }
    }
}