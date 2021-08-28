using CodeChallenge.Core.Models.CreditApplications;
using CodeChallenge.Data.Context;
using CodeChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Repositories
{
    public class AppliedAmountDecisionRepository : IAppliedAmountDecisionRepository
    {
        private CodeChallengeContext _context;

        public AppliedAmountDecisionRepository(CodeChallengeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppliedAmountDecisionModel>> Get()
        {
            return await _context.AppliedAmountDecision.ToListAsync();
        }
    }
}