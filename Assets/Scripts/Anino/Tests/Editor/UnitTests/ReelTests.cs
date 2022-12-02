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
            _reelController = new ReelController(symbolsCount, verticalSpacing, symbolsCount * verticalSpacing);
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
        public void GetMiddleRowResult_PositionIsEndPosition_ResultIsZero()
        {
            // Arrange
            _reelController.SetPosition(verticalSpacing * symbolsCount);
            var expectedResult = 0;

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

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetTopRowResult_PositionIsStartPosition_ResultIsOne()
        {
            // Arrange
            _reelController.SetPosition(0);
            var expectedResult = 1;

            // Act
            var actualResult = _reelController.GetTopRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetTopRowResult_PositionIsEndPosition_ResultIsOne()
        {
            // Arrange
            _reelController.SetPosition(verticalSpacing * symbolsCount);
            var expectedResult = 1;

            // Act
            var actualResult = _reelController.GetTopRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCase(4.75f, 3)]
        [TestCase(13.93f, 7)]
        [TestCase(23.2f, 11)]
        [TestCase(23.1f, 11)]
        [TestCase(100f, 1)]
        public void GetTopRowResult_VariedPositions(float position, int expectedResult)
        {
            // Arrange
            _reelController.SetPosition(position);

            // Act
            var actualResult = _reelController.GetTopRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBottomRowResult_PositionIsStartPosition_ResultIsLastSymbolIndex()
        {
            // Arrange
            _reelController.SetPosition(0);
            var expectedResult = symbolsCount-1;

            // Act
            var actualResult = _reelController.GetBottomRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBottomRowResult_PositionIsEndPosition_ResultIsLastSymbolIndex()
        {
            // Arrange
            _reelController.SetPosition(verticalSpacing * symbolsCount);
            var expectedResult = symbolsCount-1;

            // Act
            var actualResult = _reelController.GetBottomRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(4.75f, 1)]
        [TestCase(13.93f, 5)]
        [TestCase(23.2f, 9)]
        [TestCase(23.1f, 9)]
        [TestCase(100f,15)]
        public void GetBottomRowResult_VariedPositions(float position, int expectedResult)
        {
            // Arrange
            _reelController.SetPosition(position);

            // Act
            var actualResult = _reelController.GetBottomRowResult();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}