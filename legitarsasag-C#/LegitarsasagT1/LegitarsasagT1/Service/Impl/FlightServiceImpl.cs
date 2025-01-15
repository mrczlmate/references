using LegitarsasagT1.Entity;
using System.Collections.Generic;
using System.Linq;
using LegitarsasagT1.Repository.FlightDbContext;

namespace LegitarsasagT1.Service.Impl
{
    public class FlightServiceImpl : IFlightService
    {
        private readonly FlightDbContext flightDbContext;

        public FlightServiceImpl(FlightDbContext flightDbContext)
        {
            this.flightDbContext = flightDbContext;
        }

        public void Delete(int id)
        {
            Flight flight = FindById(id);
            flightDbContext.Flight.Remove(flight);
            flightDbContext.SaveChanges();
        }

        public List<Flight> FindAll()
        {
            return flightDbContext.Flight.ToList();
        }

        public Flight FindById(int id)
        {
            return flightDbContext.Flight.FirstOrDefault(x => x.Id == id);
        }

        public Flight Save(Flight flight)
        {
            flightDbContext.Flight.Add(flight);
            flightDbContext.SaveChanges();
            return flight;
        }

        public Flight Update(int id, Flight flight)
        {
            Flight dbflight = FindById(id);

            if (dbflight != null)
            {
                dbflight.Airline = flight.Airline;
                dbflight.DepartureCity = flight.DepartureCity;
                dbflight.DestinationCity = flight.DestinationCity;
                dbflight.Distance = flight.Distance;
                dbflight.FlightTime = flight.FlightTime;
                flightDbContext.SaveChanges();
            }

            return dbflight;
        }

        public List<Flight> Way(int fromCityId, int toCityId)
        {
            return flightDbContext.Flight.Where(x => x.DepartureCity.Id == fromCityId && x.DestinationCity.Id == toCityId).ToList();
        }
    }
}
