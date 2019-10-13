using System;
using System.Collections.Generic;
using NUnit.Framework;
using WeLoveSomeGoodAlgos;

namespace WeLoveSomeGoodAlsosTests
{
    public class HardBearAndAlmostRowTests
    {
        [Test, TestCaseSource("SolutionTestCases")]
        public static void RunSolutionTests(int numCities, Dictionary<int, int> extraRoads, int expectedTotalDistance)
        {
            // Arrange

            // Act
            var totalDistance = HardBearAndAlmostRow.RunSolution(numCities, extraRoads);

            // Assert
            Assert.AreEqual(expectedTotalDistance, totalDistance);
        }

        static object[] SolutionTestCases =
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
            },
            new object[]
            {
                1000000,
                new Dictionary<int, int>(),
                166666666666500000
            }
        };
    }
}
