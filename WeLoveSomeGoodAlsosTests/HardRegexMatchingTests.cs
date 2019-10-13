using System;
using NUnit.Framework;
using WeLoveSomeGoodAlgos;

namespace WeLoveSomeGoodAlsosTests
{
    public class HardRegexMatchingTests
    {
        [Test, TestCaseSource("SolutionTestCases")]
        public static void RunSolutionTestCases(String word, String pattern, bool isMatchExpected)
        {
            //Arrange

            //Act
            var regexMatches = HardRegExMatching.RunSolution(word, pattern);

            //Assert
            Assert.AreEqual(isMatchExpected, regexMatches);
        }

        static object[] SolutionTestCases =
        {
            new object[]
            {
                "aa",
                "a",
                false
            },
            new object[]
            {
                "aa",
                "a*",
                true
            },
            new object[]
            {
                "ab",
                ".*",
                true
            },
           new object[]
           {
               "aab",
               "c*a*b",
               true
           },
           new object[]
           {
               "mississippi",
               "mis*is*p*.",
               false
           }
        };
    }
}
