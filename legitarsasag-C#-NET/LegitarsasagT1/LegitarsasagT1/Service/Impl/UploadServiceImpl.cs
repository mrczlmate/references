using System.Collections.Generic;
using LegitarsasagT1.Entity;
using LegitarsasagT1.Repository.FlightDbContext;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LegitarsasagT1.Service.Impl
{
    public class UploadServiceImpl : IUploadService
    {
        private readonly FlightDbContext flightDbContext;

        public UploadServiceImpl(FlightDbContext flightDbContext)
        {
            this.flightDbContext = flightDbContext;
        }

        public List<City> LoadCityData(Stream inputStream)
        {
            using (StreamReader r = new StreamReader(inputStream))
            {
                for (string line = r.ReadLine(); line != null; line = r.ReadLine())
                {
                    string[] data = line.Split(";");
                    string name = data[0];
                    int population = int.Parse(data[1]);
                    flightDbContext.City.Add(new City(name, population));
                    flightDbContext.SaveChanges();
                }
            }

            return flightDbContext.City.ToList();
        }

        public List<Flight> LoadFlightData(Stream inputStream)
        {
            using (StreamReader r = new StreamReader(inputStream))
            {
                for (string line = r.ReadLine(); line != null; line = r.ReadLine())
                {
                    string[] data = line.Split(";");
                    Airline airline = flightDbContext.Airline.FirstOrDefault(x => x.AirlineName == data[0]) ??
                                      new Airline(data[0]);
                    if (!flightDbContext.Airline.Contains(airline))
                    {
                        flightDbContext.Airline.Add(airline);
                        flightDbContext.SaveChanges();
                    }
                    
                    City fromCity = flightDbContext.City.First(x => x.CityName == data[1]);
                    City toCity = flightDbContext.City.First(x => x.CityName == data[2]);
                    int distance = int.Parse(data[3]);
                    int flightTime = int.Parse(data[4]);
                    flightDbContext.Flight.Add(new Flight(airline, fromCity, toCity, distance, flightTime));
                    flightDbContext.SaveChanges();
                }
            }

            return flightDbContext.Flight.Include(x => x.Airline)
                .Include(x => x.DepartureCity)
                .Include(x => x.DestinationCity).ToList();
        }
    }
}