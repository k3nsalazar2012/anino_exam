using NUnit.Framework;
using Anino.Implementation;
using Anino.Framework;

namespace Anino.Tests
{
    public class ReelTests 
    {
        IReelController _reelController;
        float verticalSpacing = 2.32f;
        int symbolsCount = 16;

        [SetUp]
        public void SetUp()
        {
            _reelController = new ReelController(verticalSpacing, symbolsCount * verticalSpacing, null);
        }

        [Test]
        public void GetMiddleRowResult_PositionIsStartPosition_ResultIsZero()
        {
            // Arrange
            _reelController.SetPosition(0);
            var expectedResult = 0;

            // Act
            var actualResult = _reelController.GetMiddleRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetMiddleRowResult_PositionIsEndPosition_ResultIsLastSymbolIndex()
        {
            // Arrange
            _reelController.SetPosition(verticalSpacing * symbolsCount);
            var expectedResult = symbolsCount;

            // Act
            var actualResult = _reelController.GetMiddleRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(4.75f, 2)]
        [TestCase(13.93f, 6)]
        [TestCase(23.2f, 10)]
        [TestCase(23.1f, 10)]
        [TestCase(100f, 0)]
        public void GetMiddleRowResult_VariedPositions(float position, int expectedResult)
        {
            // Arrange
            _reelController.SetPosition(position);

            // Act
            var actualResult = _reelController.GetMiddleRowResult();
            UnityEngine.Debug.Log($"[expected] {expectedResult} | [actual]{actualResult}");

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}