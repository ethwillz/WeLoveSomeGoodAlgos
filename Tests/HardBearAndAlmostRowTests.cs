using System.Collections.Generic;
using WeLoveSomeGoodAlgos;
using Xunit;

namespace WeLoveSomeGoodAlsosTests
{
    public class HardBearAndAlmostRowTests
    {
        [Theory]
        [MemberData(nameof(SolutionTestCases))]
        public static void RunSolutionTests_Default_Succeeds(int numCities, Dictionary<int, int> extraRoads, long expectedTotalDistance)
        {
            // Arrange

            // Act
            var totalDistance = HardBearAndAlmostRow.RunSolution(numCities, extraRoads);

            // Assert
            Assert.Equal(expectedTotalDistance, totalDistance);
        }

        public static IEnumerable<object[]> SolutionTestCases = new List<object[]>
        {
            new object[]
            {
                4,
                new Dictionary<int, int>
                {
                    { 0, 2 },
                    { 3, 0 }
                },
                7
            },
            new object[]
            {
                5,
                new Dictionary<int, int> { { 1, 4 } },
                16
            },
            new object[]
            {
                20,
                new Dictionary<int, int>
                {
                    { 0, 6 },
                    { 2, 11 },
                    { 16, 18 }
                },
                891
            }
        };
    }
}
