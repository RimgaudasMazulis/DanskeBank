using CodeChallenge.Web.Exceptions;
using CodeChallenge.Web.Interfaces;
using CodeChallenge.Web.Models.CreditApplications;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeChallenge.Web.API
{
    [RoutePrefix("api/credit")]
    public class CreditController : ApiController
    {
        private readonly ICreditApplicationsService _creditApplicationService;

        public CreditController(ICreditApplicationsService creditApplicationService)
        {
            _creditApplicationService = creditApplicationService;
        }

        // Default

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CreditRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var resultModel = await _creditApplicationService.CalculateCreditInterestRateAndDecision(requestModel);

                return Ok(resultModel);

            }
            catch (Exception ex)
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}