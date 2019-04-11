using System.ComponentModel.DataAnnotations;
using ATMCore.Data.CustomAnnotations;

namespace ATMCore.Data.Entities
{
    public class WithdrawalRequest
    {
        [Required, Range(0.0, 1500), DivisibleBy(Divisor = 2)]
        public decimal Amount { get; set; }
    }
}