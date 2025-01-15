using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Util
{
    public sealed class Algorythm
    {

        private class DijkstraEntry
        {
            public int TotalCost { get; set; }
            public City FromCity { get; set; }

            public DijkstraEntry(int totalCost, City fromCity)
            {
                TotalCost = totalCost;
                FromCity = fromCity;
            }
        }

        public static List<City> Dijkstra(List<City> nodes, List<Flight> travels, int? airlineID)
        {
            Dictionary<City, DijkstraEntry> dijkstraTable = new Dictionary<City, DijkstraEntry>();
            foreach (var city in nodes)
            {
                dijkstraTable.Add(city, new DijkstraEntry(int.MaxValue, null));
            }
            HashSet<City> visited = new HashSet<City>();
            Queue<City> haveToVisit = new Queue<City>();

            City startPoint = nodes.OrderBy(x => x.Population).ToList()[0];
            dijkstraTable[startPoint].TotalCost = 0;
            dijkstraTable[startPoint].FromCity = startPoint;
            haveToVisit.Enqueue(startPoint);
            while (haveToVisit.Count > 0)
            {
                City current = haveToVisit.Dequeue();
                List<Flight> flights = (airlineID == null) ? GetDepartures(current, travels) : GetDepartures(current, travels.Where(x => x.Airline.Id == airlineID).ToList());

                foreach (var flight in flights)
                {
                    if (!visited.Contains(flight.DestinationCity))
                    {
                        haveToVisit.Enqueue(flight.DestinationCity);
                        if (dijkstraTable[flight.DestinationCity].TotalCost > flight.Distance + dijkstraTable[flight.DepartureCity].TotalCost)
                        {
                            dijkstraTable[flight.DestinationCity].TotalCost =
                                flight.Distance + dijkstraTable[flight.DepartureCity].TotalCost;
                            dijkstraTable[flight.DestinationCity].FromCity = flight.DepartureCity;
                        }
                    }
                }

                visited.Add(current);
            }

            City endPoint = nodes.OrderByDescending(x => x.Population).ToList()[0];

            List<City> cities = new List<City>();
            cities.Add(endPoint);
            Append(dijkstraTable, endPoint, cities);
            cities.Reverse();
            return cities;
        }

        private static void Append(Dictionary<City, DijkstraEntry> dijkstraTable, City current, List<City> cities)
        {
            City actual = dijkstraTable[current].FromCity;
            if (actual == current) return;
            cities.Add(actual);
            Append(dijkstraTable, actual, cities);
        }

        private static List<Flight> GetDepartures(City city, List<Flight> flights)
        {
            return flights.Where(flight => flight.DepartureCity.Equals(city)).ToList();
        }
    }
}
