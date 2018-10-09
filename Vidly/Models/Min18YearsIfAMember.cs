using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    //This class is used for validating whether a customer's age is atleast 18 years
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown | customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birth data is Required");

            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return age > 18 ? ValidationResult.Success : new ValidationResult("Customer must be atleast 18 years or old for membership");
        }
    }
}