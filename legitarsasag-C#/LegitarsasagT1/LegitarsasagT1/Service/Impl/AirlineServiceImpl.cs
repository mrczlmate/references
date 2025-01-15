using LegitarsasagT1.Entity;
using System.Collections.Generic;
using System.Linq;
using LegitarsasagT1.Repository.FlightDbContext;

namespace LegitarsasagT1.Service.Impl
{
    public class AirlineServiceImpl : IAirlineService
    {
        private readonly FlightDbContext flightDbContext;

        public AirlineServiceImpl(FlightDbContext flightDbContext)
        {
            this.flightDbContext = flightDbContext;
        }

        public void Delete(int id)
        {
            Airline airline = FindById(id);
            flightDbContext.Airline.Remove(airline);
            flightDbContext.SaveChanges();
        }

        public List<Airline> FindAll()
        {
            return flightDbContext.Airline.ToList();
        }

        public Airline FindById(int id)
        {
            return flightDbContext.Airline.FirstOrDefault(x => x.Id == id);
        }

        public List<Flight> FlightsByAirline(int id)
        {
            return flightDbContext.Flight.Where(x => x.Airline.Id == id).ToList();
        }

        public Airline Save(Airline airline)
        {
            flightDbContext.Airline.Add(airline);
            flightDbContext.SaveChanges();
            return airline;
        }

        public Airline Update(int id, Airline airline)
        {
            Airline dbairline = FindById(id);

            if (dbairline != null)
            {
                dbairline.AirlineName = airline.AirlineName;
                flightDbContext.SaveChanges();
            }

            return dbairline;
        }
    }
}
