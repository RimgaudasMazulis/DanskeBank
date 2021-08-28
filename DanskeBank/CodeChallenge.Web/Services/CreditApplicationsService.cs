using CodeChallenge.Core.Models.CreditApplications;
using CodeChallenge.Data.Interfaces;
using CodeChallenge.Web.Helpers;
using CodeChallenge.Web.Interfaces;
using CodeChallenge.Web.Models.CreditApplications;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Services
{
    public class CreditApplicationsService : ICreditApplicationsService
    {
        private readonly IAppliedAmountDecisionRepository _appliedAmountDecisionRepository;
        private readonly ITotalFutureDebtInterestRateRepository _totalFutureDebtInterestRateRepository;
        private readonly IMemoryCache _cache;

        public CreditApplicationsService(IAppliedAmountDecisionRepository appliedAmountDecisionRepository, ITotalFutureDebtInterestRateRepository totalFutureDebtInterestRateRepository, IMemoryCache cache)
        {
            _appliedAmountDecisionRepository = appliedAmountDecisionRepository;
            _totalFutureDebtInterestRateRepository = totalFutureDebtInterestRateRepository;
            _cache = cache;
        }

        public async Task<CreditResultModel> CalculateCreditInterestRateAndDecision(CreditRequestModel requestModel)
         {
            var resultModel = new CreditResultModel()
            {
                Decision = await CalculateDecision(requestModel),
                InterestRate = await CalculateInterestRate(requestModel)
            };

            return resultModel;
        }

        private async Task<bool> CalculateDecision(CreditRequestModel requestModel)
        {
            var cacheKey = "AppliedAmountDecisions";
            IEnumerable<AppliedAmountDecisionModel> rules;

            if (!_cache.TryGetValue(cacheKey, out rules))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(24));
                rules = await _appliedAmountDecisionRepository.Get();
                _cache.Set(cacheKey, rules, cacheEntryOptions);
            }

            return Validator.IsAbleToApplyForCredit(rules, requestModel);
        }


        private async Task<decimal> CalculateInterestRate(CreditRequestModel requestModel)
        {
            var cacheKey = "TotalFutureDebtInterestRates";
            IEnumerable<TotalFutureDebtInterestRateModel> rules;

            if (!_cache.TryGetValue(cacheKey, out rules))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(24));
                rules = await _totalFutureDebtInterestRateRepository.Get();
                _cache.Set(cacheKey, rules, cacheEntryOptions);
            }         

            return Calculate.GetInterestRateByTotalFutureDebt(rules, requestModel);
        }       
    }
}