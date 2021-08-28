using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge.Web;
using CodeChallenge.Web.Controllers;
using CodeChallenge.Web.API;
using CodeChallenge.Web.Services;
using CodeChallenge.Web.Interfaces;
using CodeChallenge.Data.Interfaces;
using CodeChallenge.Data.Context;
using CodeChallenge.Data.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using CodeChallenge.Web.Models.CreditApplications;
using System.Threading.Tasks;
using CodeChallenge.Core.Entities;
using Moq;
using System.Web.Http.Results;

namespace CodeChallenge.Tests.Controllers
{
    [TestClass]
    public class CreditControllerTest
    {
        private readonly CreditApplicationsService service;
        private readonly CreditController controller;
        public CreditControllerTest()
        {
            CodeChallengeContext context = new CodeChallengeContext();
            MemoryCacheOptions memoryCacheOptions = new MemoryCacheOptions();
            MemoryCache memoryCache = new MemoryCache(Options.Create(memoryCacheOptions));

            AppliedAmountDecisionRepository appliedAmountDecisionRepository = new AppliedAmountDecisionRepository(context);
            TotalFutureDebtInterestRateRepository totalFutureDebtInterestRateRepository = new TotalFutureDebtInterestRateRepository(context);

            service = new CreditApplicationsService(appliedAmountDecisionRepository, totalFutureDebtInterestRateRepository, memoryCache);
            controller = new CreditController(service);
        }

        [TestMethod]
        public void Post_ShouldReturnDecisionNo()
        {
            // Arrange      
            
            var appliedAmountDecisionRepositoryMock = new Mock<IAppliedAmountDecisionRepository>();
            appliedAmountDecisionRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetAppliedAmountDecisionEntities());

            var totalFutureDebtInterestRateRepositoryMock = new Mock<ITotalFutureDebtInterestRateRepository>();
            totalFutureDebtInterestRateRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetTotalFutureDebtInterestRatesEntities());

            var request = new CreditRequestModel()
            {
                AppliedCreditAmount = 1200,
                CurrentCreditAmount = 5000,
                RepaymentInMonthsTerm = 48
            };

            // Act
            var result = controller.Post(request).Result;
            var content = ((OkNegotiatedContentResult<CreditResultModel>) result).Content;
            // Assert
            Assert.IsNotNull(content);
            Assert.IsInstanceOfType(content, typeof(CreditResultModel));
            Assert.IsFalse(content.Decision);
        }

        [TestMethod]
        public void Post_ShouldReturnDecisionYes()
        {
            // Arrange      

            var appliedAmountDecisionRepositoryMock = new Mock<IAppliedAmountDecisionRepository>();
            appliedAmountDecisionRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetAppliedAmountDecisionEntities());

            var totalFutureDebtInterestRateRepositoryMock = new Mock<ITotalFutureDebtInterestRateRepository>();
            totalFutureDebtInterestRateRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetTotalFutureDebtInterestRatesEntities());

            var request = new CreditRequestModel()
            {
                AppliedCreditAmount = 6000,
                CurrentCreditAmount = 7000,
                RepaymentInMonthsTerm = 48
            };

            // Act
            var result = controller.Post(request).Result;
            var content = ((OkNegotiatedContentResult<CreditResultModel>)result).Content;
            // Assert
            Assert.IsNotNull(content);
            Assert.IsInstanceOfType(content, typeof(CreditResultModel));
            Assert.IsTrue(content.Decision);
        }

        [TestMethod]
        public void Post_ShouldReturnInterestRate5()
        {
            // Arrange      

            var appliedAmountDecisionRepositoryMock = new Mock<IAppliedAmountDecisionRepository>();
            appliedAmountDecisionRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetAppliedAmountDecisionEntities());

            var totalFutureDebtInterestRateRepositoryMock = new Mock<ITotalFutureDebtInterestRateRepository>();
            totalFutureDebtInterestRateRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetTotalFutureDebtInterestRatesEntities());

            var request = new CreditRequestModel()
            {
                AppliedCreditAmount = 23000,
                CurrentCreditAmount = 26000,
                RepaymentInMonthsTerm = 48
            };

            // Act
            var result = controller.Post(request).Result;
            var content = ((OkNegotiatedContentResult<CreditResultModel>)result).Content;
            // Assert
            Assert.IsNotNull(content);
            Assert.IsInstanceOfType(content, typeof(CreditResultModel));
            Assert.AreEqual(5, content.InterestRate);
        }

        [TestMethod]
        public void Post_ShouldReturnInterestRate3DescisionYes()
        {
            // Arrange      

            var appliedAmountDecisionRepositoryMock = new Mock<IAppliedAmountDecisionRepository>();
            appliedAmountDecisionRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetAppliedAmountDecisionEntities());

            var totalFutureDebtInterestRateRepositoryMock = new Mock<ITotalFutureDebtInterestRateRepository>();
            totalFutureDebtInterestRateRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetTotalFutureDebtInterestRatesEntities());

            var request = new CreditRequestModel()
            {
                AppliedCreditAmount = 3000,
                CurrentCreditAmount = 5000,
                RepaymentInMonthsTerm = 60
            };

            // Act
            var result = controller.Post(request).Result;
            var content = ((OkNegotiatedContentResult<CreditResultModel>)result).Content;
            // Assert
            Assert.IsNotNull(content);
            Assert.IsInstanceOfType(content, typeof(CreditResultModel));
            Assert.IsTrue(content.Decision);
            Assert.AreEqual(3, content.InterestRate);
        }

        [TestMethod]
        public void Post_ShouldReturnInterestRate6DescisionNo()
        {
            // Arrange      

            var appliedAmountDecisionRepositoryMock = new Mock<IAppliedAmountDecisionRepository>();
            appliedAmountDecisionRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetAppliedAmountDecisionEntities());

            var totalFutureDebtInterestRateRepositoryMock = new Mock<ITotalFutureDebtInterestRateRepository>();
            totalFutureDebtInterestRateRepositoryMock.Setup(a => a.Get().Result).Returns(() => GetTotalFutureDebtInterestRatesEntities());

            var request = new CreditRequestModel()
            {
                AppliedCreditAmount = 70000,
                CurrentCreditAmount = 40000,
                RepaymentInMonthsTerm = 120
            };

            // Act
            var result = controller.Post(request).Result;
            var content = ((OkNegotiatedContentResult<CreditResultModel>)result).Content;
            // Assert
            Assert.IsNotNull(content);
            Assert.IsInstanceOfType(content, typeof(CreditResultModel));
            Assert.IsFalse(content.Decision);
            Assert.AreEqual(6, content.InterestRate);
        }

        private IEnumerable<AppliedAmountDecisionEntity> GetAppliedAmountDecisionEntities()
        {
            var appliedAmountDecisions = new List<AppliedAmountDecisionEntity>()
            {
                new AppliedAmountDecisionEntity()
                {
                    Amount = 2000,
                    IsGreaterThanAmount = false,
                    Decision = false
                },
                new AppliedAmountDecisionEntity()
                {
                    Amount = 2000,
                    IsGreaterThanAmount = true,
                    Decision = true
                },
                new AppliedAmountDecisionEntity()
                {
                    Amount = 69000,
                    IsGreaterThanAmount = true,
                    Decision = false
                }
            };

            return appliedAmountDecisions;
        }

        private IEnumerable<TotalFutureDebtInterestRateEntity> GetTotalFutureDebtInterestRatesEntities()
        {
            var totalFutureDebtInterestRates = new List<TotalFutureDebtInterestRateEntity>()
            {
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 20000,
                    IsGreaterThanAmount = false,
                    AmountIsRange = false,
                    AmountRangeFrom = 0,
                    AmountRangeTo = 0,
                    InterestRate = 3
                },
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 0,
                    IsGreaterThanAmount = false,
                    AmountIsRange = true,
                    AmountRangeFrom = 20000,
                    AmountRangeTo = 39000,
                    InterestRate = 4
                },
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 0,
                    IsGreaterThanAmount = false,
                    AmountIsRange = true,
                    AmountRangeFrom = 40000,
                    AmountRangeTo = 59000,
                    InterestRate = 5
                },
                new TotalFutureDebtInterestRateEntity()
                {
                    Amount = 60000,
                    IsGreaterThanAmount = true,
                    AmountIsRange = false,
                    AmountRangeFrom = 0,
                    AmountRangeTo = 0,
                    InterestRate = 6
                },
            };

            return totalFutureDebtInterestRates;
        }
    }
}
