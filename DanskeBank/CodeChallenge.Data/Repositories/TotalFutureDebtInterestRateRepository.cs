using CodeChallenge.Core.Models.CreditApplications;
using CodeChallenge.Data.Context;
using CodeChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Repositories
{
    public class TotalFutureDebtInterestRateRepository : ITotalFutureDebtInterestRateRepository
    {
        private CodeChallengeContext _context;

        public TotalFutureDebtInterestRateRepository(CodeChallengeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TotalFutureDebtInterestRateModel>> Get()
        {
            return await _context.TotalFutureDebtInterestRate.ToListAsync();
        }
    }
}