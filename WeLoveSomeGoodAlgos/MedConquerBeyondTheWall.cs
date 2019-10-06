using System;
using System.Collections.Generic;
using System.Linq;

namespace WeLoveSomeGoodAlgos
{
    public static class MedConquerBeyondTheWall
    {
        /// <summary>
        /// https://www.codechef.com/problems/SATY0000
        ///
        /// The world is made up of islands each of which contain coordinates and a symbol. Islands of the same
        /// symbol form a nation. It's level of influence is the farthest distance between its islands. If this
        /// influence is above the dictator's dream influence, then it is considered special. The dictator wants
        /// a Y-axis attack path to conquer the minimum number of special nations needed to spell his name in
        /// the nations' symbols. Find that minimum or return int max if there is no way to accomplish this
        ///
        /// Approach:
        /// I went with my first approach on this which was just to whiteboard out the methods I'd need to
        /// handle different parts of the problem. I included all of them and added one more as an abstraction
        /// layer above one of them. The approach also changes slightly but went fairly quickly.
        /// <param name="islands">List of islands in the world which contain their coordinates and symbol</param>
        /// <param name="name">List of symbols in dictator's name</param>
        /// <param name="dreamInfluence">Dream influence level of special nations for dictator</param>
        /// <returns>Minimum number of nations to conquer on Y-axis path to spell dictator's name or int max if it's not possible</returns>
        /// </summary>
        public static int RunProblemSolution(List<Island> islands, List<int> name, double dreamInfluence)
        {
            var allSpecialNationIslands = GetAllSpecialNationIslands(dreamInfluence, islands);

            return GetMinNationsForName(name, allSpecialNationIslands);
        }

        private static List<Island> GetAllSpecialNationIslands(double dreamInfluence, List<Island> islands)
        {
            var nationSymbols = islands.Select(island => island.Symbol).Distinct().ToList();

            nationSymbols.ForEach(symbol =>
            {
                if (!IsSpecialNation(dreamInfluence, islands.Where(island => island.Symbol == symbol).ToList()))
                {
                    islands.RemoveAll(island => island.Symbol == symbol);
                }
            });

            return islands;
        }

        private static bool IsSpecialNation(double dreamInfluence, List<Island> nationIslands)
        {
            if(nationIslands.Count == 1)
            {
                return false;
            }

            double maxInfluence = int.MinValue;
            double influence;
            for (int indexOne = 0; indexOne < nationIslands.Count - 1; indexOne++)
            {
                for (int indexTwo = indexOne + 1; indexTwo < nationIslands.Count; indexTwo++)
                {
                    if ((influence = CalculateInfluence(nationIslands[indexOne], nationIslands[indexTwo])) > maxInfluence)
                    {
                        maxInfluence = influence;
                    }
                }
            }

            return maxInfluence > dreamInfluence;
        }

        private static double CalculateInfluence(Island one, Island two)
        {
            return Math.Sqrt(Math.Pow(one.X - two.X, 2) + Math.Pow(one.Y - two.Y, 2));
        }

        private static int GetMinNationsForName(List<int> name, List<Island> islands)
        {
            int minNations = int.MaxValue;
            var yAxesInEmpire = islands.Select(island => island.Y).Distinct().ToList();
            yAxesInEmpire.ForEach(yAxis =>
            {
                var symbolsOnAxis = islands
                    .Where(island => island.Y == yAxis)
                    .Select(island => island.Symbol)
                    .Distinct()
                    .ToList();

                if (name.All(symbol => symbolsOnAxis.Contains(symbol)) && symbolsOnAxis.Count < minNations)
                {
                    minNations = symbolsOnAxis.Count;
                }
            });

            return minNations;
        }

        public class Island
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Symbol { get; set; }
        }
    }
}
