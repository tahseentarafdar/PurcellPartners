using NUnit.Framework;
using PurcellPartners;

namespace UnitTests
{
    [TestFixture]
    public class GapFinderTests
    {
        private GapFinder GapFinder = new GapFinder();

        [Test]
        public void GracefullyHandlesBadOrTrivialInput()
        {
            Assert.That(GapFinder.Find(null), Is.EqualTo(-1));
            Assert.That(GapFinder.Find(Array.Empty<int>()), Is.EqualTo(-1));
            Assert.That(GapFinder.Find([2]), Is.EqualTo(-1));
        }

        [Test]
        public void CorrectResponseWhenNoGapsAreFound()
        {
            Assert.That(GapFinder.Find([2, 3, 4, 5]), Is.EqualTo(-1));
        }

        [TestCase(new int[] {4, 1, 2}, 3)]
        [TestCase(new int[] {2, 0}, 1)]
        [TestCase(new int[] {1, 2, 3, 4, 6}, 5)]
        [TestCase(new int[] {7, 6, 5, 3}, 4)]
        public void ReturnsCorrectNumber(int[] numbers, int expectedResult)
        {
            var missing = GapFinder.Find(numbers);
            Assert.That(missing, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformanceTest()
        {
            var rand = new Random();
            var largeList = new int[1000000];
            var skipNumber = 534534;
            var nextNumber = 0;
            for(int i = 0; i < largeList.Length; i++)
            {
                largeList[i] = nextNumber++;
                if(nextNumber == skipNumber)
                {
                    nextNumber++;
                }
            }

            var randomized = largeList.OrderBy(x => rand.Next()).ToArray();

            var startTime = DateTime.Now;
            Assert.That(GapFinder.Find(randomized), Is.EqualTo(skipNumber));
            var endTime = DateTime.Now;
            var totalTime = (endTime - startTime).TotalMilliseconds;
            Assert.That(totalTime, Is.LessThan(500));
        }
    }
}
