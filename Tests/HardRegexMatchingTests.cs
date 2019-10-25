using System;
using System.Collections.Generic;
using WeLoveSomeGoodAlgos;
using Xunit;

namespace WeLoveSomeGoodAlsosTests
{
    public class HardRegexMatchingTests
    {
        [Theory]
        [MemberData(nameof(SolutionTestCases))]
        public static void RunSolutionTestCases_Default_Succeeds(String word, String pattern, bool isMatchExpected)
        {
            //Arrange

            //Act
            var regexMatches = HardRegExMatching.RunSolution(word, pattern);

            //Assert
            Assert.Equal(isMatchExpected, regexMatches);
        }

        public static IEnumerable<object[]> SolutionTestCases = new List<object[]>
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
