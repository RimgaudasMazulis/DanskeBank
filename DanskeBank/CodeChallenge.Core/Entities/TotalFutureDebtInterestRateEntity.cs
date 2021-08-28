using CodeChallenge.Core.Models.CreditApplications;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Core.Entities
{
    public class TotalFutureDebtInterestRateEntity : TotalFutureDebtInterestRateModel
    {
        [Key]
        public int Id { get; set; }
    }
}
