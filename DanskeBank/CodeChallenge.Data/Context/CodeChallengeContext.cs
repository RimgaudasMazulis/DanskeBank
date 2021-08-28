using CodeChallenge.Core.Entities;
using System.Data.Entity;

namespace CodeChallenge.Data.Context
{
    public class CodeChallengeContext : DbContext
    {
        public CodeChallengeContext() 
            : base("Default")
        {
        }

        public DbSet<AppliedAmountDecisionEntity> AppliedAmountDecision { get; set; }
        public DbSet<TotalFutureDebtInterestRateEntity> TotalFutureDebtInterestRate { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppliedAmountDecisionEntity>().ToTable("AppliedAmountDecision");
            modelBuilder.Entity<TotalFutureDebtInterestRateEntity>().ToTable("TotalFutureDebtInterestRate");
        }
    }
}
