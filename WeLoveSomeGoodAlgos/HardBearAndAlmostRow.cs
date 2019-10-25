using System.Collections.Generic;
using System.Linq;

namespace WeLoveSomeGoodAlgos
{
    public static class HardBearAndAlmostRow
    {
        /// <summary>
        /// https://www.codechef.com/problems/ALMROW
        ///
        /// this problem has a list of cities and assumes that each city has a road
        /// to the next one. Additionally, there may be any number of extra roads
        /// between cities. This calculates the total distance made up of the min
        /// distance between every city.
        ///
        /// Approach:
        /// I used Djikstra's to perform each individual city calculation and just
        /// cycled through all the cities performing that operation. I believe the
        /// big O runtime of this solution is O(V^2*E) because each city combination
        /// must be checked and the runtime of Djikstra's is O(ElogV) so we can drop
        /// the log since V^2 exceeds this. Not sure on this.
        ///
        /// Alternative approach:
        /// This seems like a good candidate for a different kind of solution. I
        /// was thinking maybe a DP problem because I traversed many of the roads
        /// multiple times and it seems optimal to cache these. Update: tried to
        /// look at other solutions to see about this and they're completely
        /// unreadble. Best solution literally names functions func1-14 so I don't
        /// think I'll get much insight on this.
        /// </summary>
        /// <param name="numCities"></param>
        /// <param name="extraRoads"></param>
        /// <returns></returns>
        public static long RunSolution(int numCities, Dictionary<int, int> extraRoads)
        {
            long minDistSum = 0;

            var allRoads = GenerateFullRoadList(numCities, extraRoads);

            for(int cityFromIndex = 0; cityFromIndex < numCities - 1; cityFromIndex++)
            {
                for(int cityToIndex = cityFromIndex + 1; cityToIndex < numCities; cityToIndex++)
                {
                    minDistSum += GetMinDistBtCities(cityFromIndex, cityToIndex, allRoads);
                }
            }

            return minDistSum;
        }

        public static Dictionary<int, List<int>> GenerateFullRoadList(int numCities, Dictionary<int, int> extraRoads)
        {
            Dictionary<int, List<int>> allRoads = new Dictionary<int, List<int>>();

            Enumerable.Range(0, numCities - 1)
                .ToList()
                .ForEach(cityIndex =>
            {
                CreateOrAppendDest(ref allRoads, cityIndex, cityIndex + 1);
                CreateOrAppendDest(ref allRoads, cityIndex + 1, cityIndex); //bidirectional
            });

            foreach (var road in extraRoads)
            {
                CreateOrAppendDest(ref allRoads, road.Key, road.Value);
                CreateOrAppendDest(ref allRoads, road.Value, road.Key);
            }

            return allRoads;
        }

        public static void CreateOrAppendDest(ref Dictionary<int, List<int>> allRoads, int src, int dest)
        {
            if (allRoads.ContainsKey(src))
            {
                allRoads.TryGetValue(src, out List<int> allDests);
                allDests.Add(dest);

                allRoads.Remove(src);
                allRoads.Add(src, allDests);
            }
            else
            {
                allRoads.Add(src, new List<int>(new[] { dest }));
            }
        }

        public static int GetMinDistBtCities(int src, int dest, Dictionary<int, List<int>> allRoads)
        {
            Dictionary<int, int> citiesWithSrcDist = new Dictionary<int, int>();

            citiesWithSrcDist.Add(src, 0);

            var shortestPath = int.MaxValue;

            while (citiesWithSrcDist.Count > 0 && citiesWithSrcDist.Values.Any(dist => shortestPath > dist))
            {
                var curCity = citiesWithSrcDist.OrderBy(map => map.Value).First().Key;
                citiesWithSrcDist.TryGetValue(curCity, out int nextDist);
                nextDist++;

                allRoads.TryGetValue(curCity, out List<int> nextCities);

                nextCities.ForEach(nextCity =>
                {
                    if (nextCity == dest && nextDist < shortestPath)
                    {
                        shortestPath = nextDist;
                    }
                    else if (citiesWithSrcDist.ContainsKey(nextCity))
                    {
                        citiesWithSrcDist.TryGetValue(nextCity, out int altDistToCity);

                        if (nextDist < altDistToCity)
                        {
                            citiesWithSrcDist.Remove(nextCity);
                            citiesWithSrcDist.Add(nextCity, nextDist);
                        }
                    }
                    else
                    {
                        citiesWithSrcDist.Add(nextCity, nextDist);
                    }
                });

                citiesWithSrcDist.Remove(curCity);
            }

            return shortestPath;
        }
    }
}
