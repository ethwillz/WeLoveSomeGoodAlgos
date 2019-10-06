using System;
using System.Collections.Generic;
using NUnit.Framework;
using WeLoveSomeGoodAlgos;

namespace WeLoveSomeGoodAlsosTests
{
    public class MedConquerBeyondTheWallTests
    {
        [Test, TestCaseSource("SolutionPossibleTestCases"), TestCaseSource("SolutionImpossibleTestCases")]
        public void RunSolutionTests(List<MedConquerBeyondTheWall.Island> islands, List<int> name, int dreamInfluence, int solution)
        {
            // Arrange

            // Act
            var calculatedSolution = MedConquerBeyondTheWall.RunProblemSolution(islands, name, dreamInfluence);

            // Asssert
            Assert.AreEqual(solution, calculatedSolution);
        }

        static object[] SolutionPossibleTestCases = {
            new object[]
            {
                new List<MedConquerBeyondTheWall.Island>(new[] {
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 0,
                        Y = 0,
                        Symbol = 1
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 10,
                        Y = 0,
                        Symbol = 1
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 0,
                        Y = 1,
                        Symbol = 2
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 3,
                        Y = 1,
                        Symbol = 2
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 1,
                        Y = 2,
                        Symbol = 2
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 7,
                        Y = 1,
                        Symbol = 3
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 10,
                        Y = 1,
                        Symbol = 3
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 8,
                        Y = 2,
                        Symbol = 3
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 8,
                        Y = 0,
                        Symbol = 4
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 1,
                        Y = 4,
                        Symbol = 4
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 8,
                        Y = 4,
                        Symbol = 4
                    },
                }),
                new List<int>(new []{
                    1,
                    4
                }),
                1,
                2
            }
        };

        static object[] SolutionImpossibleTestCases =
        {
            new object[]
            {
                new List<MedConquerBeyondTheWall.Island>(new[] {
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 0,
                        Y = 0,
                        Symbol = 1
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 10,
                        Y = 0,
                        Symbol = 1
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 0,
                        Y = 1,
                        Symbol = 2
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 3,
                        Y = 1,
                        Symbol = 2
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 1,
                        Y = 2,
                        Symbol = 2
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 7,
                        Y = 1,
                        Symbol = 3
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 10,
                        Y = 1,
                        Symbol = 3
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 8,
                        Y = 2,
                        Symbol = 3
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 8,
                        Y = 3,
                        Symbol = 4
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 1,
                        Y = 4,
                        Symbol = 4
                    },
                    new MedConquerBeyondTheWall.Island
                    {
                        X = 8,
                        Y = 4,
                        Symbol = 4
                    },
                }),
                new List<int>(new []{
                    1,
                    4
                }),
                1,
                int.MaxValue
            }
        };
    }
}
