using LegitarsasagT1.Entity;
using System.Collections.Generic;
using System.Linq;
using LegitarsasagT1.Repository.FlightDbContext;

namespace LegitarsasagT1.Service.Impl
{
    public class CityServiceImpl : ICityService
    {
        private readonly FlightDbContext flightDbContext;

        public CityServiceImpl(FlightDbContext flightDbContext)
        {
            this.flightDbContext = flightDbContext;
        }

        public void Delete(int id)
        {
            City city = FindById(id);
            flightDbContext.City.Remove(city);
            flightDbContext.SaveChanges();
        }

        public List<City> FindAll()
        {
            return flightDbContext.City.ToList();
        }

        public City FindById(int id)
        {
            return flightDbContext.City.FirstOrDefault(x => x.Id == id);
        }

        public City Save(City city)
        {
            flightDbContext.City.Add(city);
            flightDbContext.SaveChanges();
            return city;
        }

        public City Update(int id, City city)
        {
            City dbcity = FindById(id);

            if (dbcity != null)
            {
                dbcity.CityName = city.CityName;
                dbcity.Population = city.Population;
                flightDbContext.SaveChanges();
            }
            return dbcity;
        }
    }
}
