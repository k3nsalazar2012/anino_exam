using NUnit.Framework;
using Anino.Framework;
using Anino.Implementation;
using System.Collections.Generic;

namespace Anino.Tests
{
    public class PayoutServiceTests
    {
        IPayoutService payoutService;
        List<List<int>> payoutLines;
        List<List<int>> spinResults;
        [SetUp]
        public void SetUp()
        {
            payoutService = new PayoutService();

            List<int> payoutLine1 = new List<int>{0,0,0,0,0,1,1,1,1,1,0,0,0,0,0};
            List<int> payoutLine2 = new List<int>{1,1,1,1,1,0,0,0,0,0,0,0,0,0,0};
            List<int> payoutLine3 = new List<int>{0,0,0,0,0,0,0,0,0,0,1,1,1,1,1};

            payoutLines = new List<List<int>>{payoutLine1, payoutLine2, payoutLine3};

            payoutService.SetPayoutLines(payoutLines);
        }

        [Test]
        public void HasPayout_GetPayoutLinesHitCount_ResultsHasValidPayoutLine_ResultIsTrueAndThree()
        {
            // Arrange
            List<int> reel1 = new List<int>{1,2,3};
            List<int> reel2 = new List<int>{1,2,3};
            List<int> reel3 = new List<int>{1,2,3};
            List<int> reel4 = new List<int>{1,2,3};
            List<int> reel5 = new List<int>{1,2,3};
            spinResults = new List<List<int>>{reel1, reel2, reel3, reel4, reel5};

            payoutService.SetResults(spinResults);
            bool expectedBoolResult = true;
            int expectedIntResult = 3;

            // Act
            bool actualBoolResult = payoutService.HasPayout();
            int actualIntResult = payoutService.GetPayoutLinesHitCount();

            // Assert
            Assert.AreEqual(expectedBoolResult, actualBoolResult);
            Assert.AreEqual(expectedIntResult, actualIntResult);
        }

        [Test]
        public void HasPayout_GetPayoutLinesHitCount_ResultsHasNoValidPayoutLines_ResultIsFalseAndZero()
        {
            // Arrange
            List<int> reel1 = new List<int>{1,2,3};
            List<int> reel2 = new List<int>{4,5,6};
            List<int> reel3 = new List<int>{7,8,9};
            List<int> reel4 = new List<int>{10,11,12};
            List<int> reel5 = new List<int>{13,14,15};
            spinResults = new List<List<int>>{reel1, reel2, reel3, reel4, reel5};

            payoutService.SetResults(spinResults);
            bool expectedBoolResult = false;
            int expectedIntResult = 0;

            // Act
            bool actualBoolResult = payoutService.HasPayout();
            int actualIntResult = payoutService.GetPayoutLinesHitCount();

            // Assert
            Assert.AreEqual(expectedBoolResult, actualBoolResult);
            Assert.AreEqual(expectedIntResult, actualIntResult);
        }
    }
}