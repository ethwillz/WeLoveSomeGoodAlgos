using System.Collections.Generic;
using System.Linq;
using WeLoveSomeGoodAlgos;
using Xunit;

namespace WeLoveSomeGoodAlsosTests
{
    public class EasyFibonnaciTests
    {
        [Theory]
        [MemberData(nameof(IndexAndFibNumber))]
        public void RunClosedFormFibTests_Default_Succeeds(int index, int correctFibNum)
        {
            // Arrange

            // Act
            var calculatedFibNum = EasyFibonnaci.GetFibNum(index);

            // Assert
            Assert.Equal(correctFibNum, calculatedFibNum);
        }

        [Theory]
        [MemberData(nameof(TestFencesAndAnswers))]
        public void RunSolutionTests_Default_Succeeds(int fence, int answer)
        {
            // Arrange

            // Act
            var calculatedAnswer = EasyFibonnaci.RunSolutionForFence(fence);

            // Assert
            Assert.Equal(answer, calculatedAnswer);
        }

        public static IEnumerable<object[]> TestFencesAndAnswers = GenerateTestFencesAndAnswers();
        public static IEnumerable<object[]> IndexAndFibNumber = new List<object[]>
        {
            new object[] { 0, 0 },
            new object[] { 1, 1 },
            new object[] { 2, 1 },
            new object[] { 3, 2 },
            new object[] { 4, 3 },
            new object[] { 5, 5 },
            new object[] { 6, 8 }
        };

        private static List<object[]> GenerateTestFencesAndAnswers()
        {
            int[] fenceAnswers = { 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 0 };
            var testFencesAndAnswers = new List<object[]>();
            
            Enumerable.Range(0, 15)
                .ToList()
                .ForEach(fence => {
                    var obj = new object[] { fence, fenceAnswers[fence] };
                    testFencesAndAnswers.Add(obj);
                });

            return testFencesAndAnswers;
        }
    }
}
