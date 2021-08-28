using CodeChallenge.Core.Models.CreditApplications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Interfaces
{
    public interface ITotalFutureDebtInterestRateRepository
    {
        Task<IEnumerable<TotalFutureDebtInterestRateModel>> Get();
    }
}