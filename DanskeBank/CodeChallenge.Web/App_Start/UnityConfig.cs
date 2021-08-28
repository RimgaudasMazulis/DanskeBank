using CodeChallenge.Data.Context;
using CodeChallenge.Data.Interfaces;
using CodeChallenge.Data.Repositories;
using CodeChallenge.Web.Interfaces;
using CodeChallenge.Web.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Unity;
using Unity.WebApi;

namespace CodeChallenge.Web
{
    public static class UnityConfig
    {
        public static UnityDependencyResolver RegisterComponents()
        {
			var container = new UnityContainer();

            //Cache:
            MemoryCacheOptions memoryCacheOptions = new MemoryCacheOptions
            {
                //config your cache here
            };

            MemoryCache memoryCache = new MemoryCache(Options.Create(memoryCacheOptions));
            container.RegisterInstance<IMemoryCache>(memoryCache);

            // Context:
            container.RegisterType<CodeChallengeContext>();

            // Services:
            container.RegisterType<ICreditApplicationsService, CreditApplicationsService>();

            // Repositories:
            container.RegisterType<IAppliedAmountDecisionRepository, AppliedAmountDecisionRepository>();
            container.RegisterType<ITotalFutureDebtInterestRateRepository, TotalFutureDebtInterestRateRepository>();

            return new UnityDependencyResolver(container);
        }
    }
}