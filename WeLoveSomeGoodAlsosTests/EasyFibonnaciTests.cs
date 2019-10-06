using System.Linq;
using NUnit.Framework;
using WeLoveSomeGoodAlgos;

namespace WeLoveSomeGoodAlsosTests
{
    public class EasyFibonnaciTests
    {
        [Test, TestCaseSource("IndexAndFibNumber")]
        public void RunClosedFormFibTests(int index, int correctFibNum)
        {
            // Arrange

            // Act
            var calculatedFibNum = EasyFibonnaci.GetFibNum(index);

            // Assert
            Assert.AreEqual(correctFibNum, calculatedFibNum);
        }

        [Test, TestCaseSource("TestFencesAndAnswers")]
        public void RunSolutionTests(int fence, int answer)
        {
            // Arrange

            // Act
            var calculatedAnswer = EasyFibonnaci.RunSolutionForFence(fence);

            // Assert
            Assert.AreEqual(answer, calculatedAnswer);
        }

        static object[] TestFencesAndAnswers = GenerateTestFencesAndAnswers();
        static object[] IndexAndFibNumber = {
            new object[] { 0, 0 },
            new object[] { 1, 1 },
            new object[] { 2, 1 },
            new object[] { 3, 2 },
            new object[] { 4, 3 },
            new object[] { 5, 5 },
            new object[] { 6, 8 }
        };

        private static object[] GenerateTestFencesAndAnswers()
        {
            int[] fenceAnswers = { 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 0 };
            var testFencesAndAnswers = new object[fenceAnswers.Count()];
            
            Enumerable.Range(0, 16)
                .ToList()
                .ForEach(fence => testFencesAndAnswers[fence] = new object[] { fence, fenceAnswers[fence] });

            return testFencesAndAnswers;
        }
    }
}
