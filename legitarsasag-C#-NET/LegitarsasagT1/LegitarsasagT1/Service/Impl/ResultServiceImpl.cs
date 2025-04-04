using LegitarsasagT1.Entity;
using LegitarsasagT1.Repository.FlightDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using LegitarsasagT1.Util;
using Microsoft.EntityFrameworkCore;

namespace LegitarsasagT1.Service.Impl
{
    public class ResultServiceImpl : IResultService
    {
        private readonly FlightDbContext flightDbContext;

        public ResultServiceImpl(FlightDbContext flightDbContext)
        {
            this.flightDbContext = flightDbContext;
        }

        public List<Flight> AllFlight()
        {
            return GetPath(null);

        }

        public List<Flight> AllFlightByAirline(int id)
        {
            return GetPath(id);
        }

        private List<Flight> GetPath(int? airlineID)
        {
            List<Flight> result = new List<Flight>();
            List<City> dijkstra = Algorythm.Dijkstra(flightDbContext.City.ToList(), flightDbContext.Flight.Include(x => x.Airline).ToList(), airlineID);

            for (int i = 0; i < dijkstra.Count - 1; i++)
            {
                City from = dijkstra[i];
                City to = dijkstra[i + 1];
                List<Flight> flights = flightDbContext.Flight.Where(x => x.DepartureCity.Id == from.Id && x.DestinationCity.Id == to.Id).Include(x => x.Airline).ToList();
                result.Add(flights.OrderBy(x => x.FlightTime).ToList()[0]);
            }
            return result;
        }
    }
}
