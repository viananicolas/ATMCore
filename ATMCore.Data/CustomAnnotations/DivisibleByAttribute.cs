using System;
using System.ComponentModel.DataAnnotations;

namespace ATMCore.Data.CustomAnnotations
{
    public class DivisibleByAttribute : ValidationAttribute
    {
        public int Divisor { get; set; }
        protected override ValidationResult IsValid(object country, ValidationContext validationContext)
        {
            var value = Convert.ToDecimal(country);
            return value % Divisor == 0
                ? ValidationResult.Success
                : new ValidationResult("Invalid value. Try again.");
        }
    }
}