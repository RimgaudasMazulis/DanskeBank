namespace CodeChallenge.Core.Models.CreditApplications
{
    public class CreditDataBaseModel
    {
        public decimal Amount { get; set; }
        public bool IsGreaterThanAmount { get; set; }
        public bool AmountIsRange { get; set; }
        public decimal AmountRangeFrom { get; set; }
        public decimal AmountRangeTo { get; set; }
    }
}