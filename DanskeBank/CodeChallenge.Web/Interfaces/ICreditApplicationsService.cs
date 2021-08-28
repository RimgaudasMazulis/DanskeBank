using CodeChallenge.Web.Models.CreditApplications;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Interfaces
{
    public interface ICreditApplicationsService
    {
        Task<CreditResultModel> CalculateCreditInterestRateAndDecision(CreditRequestModel requestModel);
    }
}