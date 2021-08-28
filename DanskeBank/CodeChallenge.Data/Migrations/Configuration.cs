namespace CodeChallenge.Data.Migrations
{
    using CodeChallenge.Core.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeChallenge.Data.Context.CodeChallengeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeChallenge.Data.Context.CodeChallengeContext context)
        {
            var appliedAmountDecisions = new List<AppliedAmountDecisionEntity>()
            {
                new AppliedAmountDecisionEntity()
                {
                    Amount = 2000,
                    IsGreaterThanAmount = false,
                    Decision = false
                },
                new AppliedAmountDecisionEntity()
                {
                    Amount = 2000,
                    IsGreaterThanAmount = true,
                    Decision = true
                },
                new AppliedAmountDecisionEntity()
                {
                    Amount = 69000,
                    IsGreaterThanAmount = true,
                    Decision = false
                }
            };

            foreach (var appliedAmountDecision in appliedAmountDecisions)
            {
                context.AppliedAmountDecision.Add(appliedAmountDecision);
            }

            var totalFutureDebtInterestRates = new List<TotalFutureDebtInterestRateEntity>()
            {
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 20000,
                    IsGreaterThanAmount = false,
                    AmountIsRange = false,
                    AmountRangeFrom = 0,
                    AmountRangeTo = 0,
                    InterestRate = 3
                },
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 0,
                    IsGreaterThanAmount = false,
                    AmountIsRange = true,
                    AmountRangeFrom = 20000,
                    AmountRangeTo = 39000,
                    InterestRate = 4
                },
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 0,
                    IsGreaterThanAmount = false,
                    AmountIsRange = true,
                    AmountRangeFrom = 40000,
                    AmountRangeTo = 59000,
                    InterestRate = 5
                },
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 60000,
                    IsGreaterThanAmount = true,
                    AmountIsRange = false,
                    AmountRangeFrom = 0,
                    AmountRangeTo = 0,
                    InterestRate = 6
                },
            };

            foreach (var totalFutureDebtInterestRate in totalFutureDebtInterestRates)
            {
                context.TotalFutureDebtInterestRate.Add(totalFutureDebtInterestRate);
            }

            context.SaveChanges();
        }
    }
}
