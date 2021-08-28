using CodeChallenge.Core.Models.CreditApplications;
using CodeChallenge.Web.Models.CreditApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge.Web.Helpers
{
    public static class Validator
    {
        public static bool IsAbleToApplyForCredit(IEnumerable<AppliedAmountDecisionModel> rules, CreditRequestModel requestModel)
        {
            if (rules == null || requestModel == null)
            {
                throw new ArgumentNullException();
            }

            var isAbleToApplyForCredit = false;

            foreach (var rule in rules)
            {
                if (rule.AmountIsRange)
                {
                    if (rule.AmountRangeFrom <= requestModel.AppliedCreditAmount && requestModel.AppliedCreditAmount <= rule.AmountRangeTo)
                    {
                        isAbleToApplyForCredit = rule.Decision;
                    }
                }

                if (rule.IsGreaterThanAmount)
                {
                    if (rule.Amount < requestModel.AppliedCreditAmount)
                    {
                        isAbleToApplyForCredit = rule.Decision;
                    }
                }                                          

                if (!rule.IsGreaterThanAmount)
                {
                    if (rule.Amount > requestModel.AppliedCreditAmount)
                    {
                        isAbleToApplyForCredit = rule.Decision;
                    }
                }
            }

            return isAbleToApplyForCredit;
        }        
    }
}