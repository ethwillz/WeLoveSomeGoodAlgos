using System.Collections.Generic;
using System.Linq;

namespace WeLoveSomeGoodAlgos
{
    public static class HardBearAndAlmostRow
    {
        // TODO make more descriptive and write docs with runtime (based off of Dkikstra)
        public static int RunSolution(int numCities, Dictionary<int, int> extraRoads)
        {
            int minDistSum = 0;

            var allRoads = GenerateFullRoadList(numCities, extraRoads);

            for(int cityFromIndex = 0; cityFromIndex < numCities - 2; cityFromIndex++)
            {
                for(int cityToIndex = cityFromIndex + 1; cityToIndex < numCities; cityToIndex++)
                {
                    minDistSum += GetMinDistCities(cityFromIndex, cityToIndex, allRoads);
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

        public static int GetMinDistCities(int src, int dest, Dictionary<int, List<int>> allRoads)
        {
            Dictionary<int, int> cityDistMap = new Dictionary<int, int>();

            allRoads.TryGetValue(src, out List<int> nextCities);

            nextCities.ForEach(next =>
            {
                cityDistMap.Add(next, 1);
            });

            return CalculateShortestPath(cityDistMap, allRoads, dest);
        }

        private static int CalculateShortestPath(Dictionary<int, int> cityDistMap, Dictionary<int, List<int>> allRoads, int dest)
        {
            var shortestPath = int.MaxValue;

            while (cityDistMap.Count > 0 && cityDistMap.Values.Any(dist => shortestPath > dist))
            {
                var curCity = cityDistMap.First().Key;
                cityDistMap.TryGetValue(curCity, out int nextDist);
                nextDist++;

                allRoads.TryGetValue(curCity, out List<int> nextCities);

                nextCities.ForEach(next =>
                {
                    cityDistMap.Remove(curCity);

                    if (next == dest && nextDist < shortestPath)
                    {
                        shortestPath = nextDist;
                    }
                    else if (cityDistMap.ContainsKey(next))
                    {
                        cityDistMap.TryGetValue(next, out int altDistToCity);

                        if (nextDist < altDistToCity)
                        {
                            cityDistMap.Remove(next);
                            cityDistMap.Add(next, nextDist);
                        }
                    }
                    else
                    {
                        cityDistMap.Add(next, nextDist);
                    }
                });
            }

            return shortestPath;
        }
    }
}
