using CodeChallenge.Core.Models.CreditApplications;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Core.Entities
{
    public class AppliedAmountDecisionEntity : AppliedAmountDecisionModel
    {
        [Key]
        public int Id { get; set; }
    }
}
