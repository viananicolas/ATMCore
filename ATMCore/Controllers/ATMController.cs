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
            2m, 5m, 10m, 20m, 50m, 100m
        };
        [HttpPost]
        public IActionResult PostWithdrawal([FromBody] WithdrawalRequest withdrawalRequest)
        {
            if(withdrawalRequest.Amount % 2 == 0)
                return Ok(CheckBankNotes(withdrawalRequest));
            return BadRequest("Invalid value");
        }

        private static Withdrawal CheckBankNotes(WithdrawalRequest withdrawalRequest)
        {
            var withdrawal = new Withdrawal();
            while (withdrawalRequest.Amount >= BankNotes[5])
            {
                withdrawalRequest.Amount -= BankNotes[5];
                withdrawal.HundredReaisAmount++;
            }
            while (withdrawalRequest.Amount >= BankNotes[4])
            {
                withdrawalRequest.Amount -= BankNotes[4];
                withdrawal.FiftyReaisAmount++;
            }
            while (withdrawalRequest.Amount >= BankNotes[3])
            {
                withdrawalRequest.Amount -= BankNotes[3];
                withdrawal.TwentyReaisAmount++;
            }
            while (withdrawalRequest.Amount >= BankNotes[2])
            {
                withdrawalRequest.Amount -= BankNotes[2];
                withdrawal.TenReaisAmount++;
            }
            while (withdrawalRequest.Amount >= BankNotes[1])
            {
                withdrawalRequest.Amount -= BankNotes[1];
                withdrawal.FiveReaisAmount++;
            }
            while (withdrawalRequest.Amount >= BankNotes[0])
            {
                withdrawalRequest.Amount -= BankNotes[0];
                withdrawal.TwoReaisAmount++;
            }

            return withdrawal;
        }
    }
}