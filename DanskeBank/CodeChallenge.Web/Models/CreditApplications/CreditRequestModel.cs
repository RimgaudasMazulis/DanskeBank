using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeChallenge.Web.Models.CreditApplications
{
    public class CreditRequestModel
    {
        [Required]
        public decimal AppliedCreditAmount { get; set; }

        [Required]
        public decimal CurrentCreditAmount { get; set; }

        public int RepaymentInMonthsTerm { get; set; }
    }
}