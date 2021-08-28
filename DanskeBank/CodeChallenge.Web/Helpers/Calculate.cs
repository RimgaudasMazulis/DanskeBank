using CodeChallenge.Core.Models.CreditApplications;
using CodeChallenge.Web.Models.CreditApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge.Web.Helpers
{
    public static class Calculate
    {
        public static decimal GetInterestRateByTotalFutureDebt(IEnumerable<TotalFutureDebtInterestRateModel> rules, CreditRequestModel requestModel)
        {
            if (rules == null || requestModel == null)
            {
                throw new ArgumentNullException();
            }

            decimal interestRate = 0;
            var creditAmountsCombined = requestModel.AppliedCreditAmount + requestModel.CurrentCreditAmount;

            foreach (var rule in rules)
            {
                if (rule.AmountIsRange)
                {
                    if (rule.AmountRangeFrom <= creditAmountsCombined && creditAmountsCombined <= rule.AmountRangeTo)
                    {
                        interestRate = rule.InterestRate;
                    }
                }

                if (rule.IsGreaterThanAmount)
                {
                    if (rule.Amount < creditAmountsCombined)
                    {
                        interestRate = rule.InterestRate;
                    }
                }

                if (!rule.IsGreaterThanAmount)
                {
                    if (rule.Amount > creditAmountsCombined)
                    {
                        interestRate = rule.InterestRate;
                    }
                }
            }

            return interestRate;
        }

        public static decimal GetYears(int months)
        {
            return months / 12;
        }
    }
}