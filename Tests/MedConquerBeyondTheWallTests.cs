using System.Collections.Generic;
using WeLoveSomeGoodAlgos;
using Xunit;

namespace WeLoveSomeGoodAlsosTests
{
    public class MedConquerBeyondTheWallTests
    {
        [Theory, MemberData(nameof(SolutionPossibleTestCases))]
        public void RunPossibleSolution_Default_Succeeds(List<MedConquerBeyondTheWall.Island> islands, List<int> name, int dreamInfluence, int solution)
        {
            // Arrange

            // Act
            var calculatedSolution = MedConquerBeyondTheWall.RunSolutionForWorld(islands, name, dreamInfluence);

            // Asssert
            Assert.Equal(solution, calculatedSolution);
        }

        [Theory, MemberData(nameof(SolutionImpossibleTestCases))]
        public void RunImpossibleSolutionTests_Default_Succeeds(List<MedConquerBeyondTheWall.Island> islands, List<int> name, int dreamInfluence, int solution)
        {
            // Arrange

            // Act
            var calculatedSolution = MedConquerBeyondTheWall.RunSolutionForWorld(islands, name, dreamInfluence);

            // Asssert
            Assert.Equal(solution, calculatedSolution);
        }

        public static IEnumerable<object[]> SolutionPossibleTestCases = new List<object[]>
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

        public static IEnumerable<object[]> SolutionImpossibleTestCases = new List<object[]>
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
