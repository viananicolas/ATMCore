using System.ComponentModel.DataAnnotations;

namespace ATMCore.Data.Entities
{
    public class WithdrawalRequest
    {
        [Required, Range(0.0, 1500)]
        public decimal Amount { get; set; }
    }
}